using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtDecoMebel;
using ArtDecoMebel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace ArtDecoMebel.Areas.Underprivileged.Controllers
{
    [Area("Underprivileged")]
    public class FurnituresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FurnituresController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Underprivileged/Furnitures
        public async Task<IActionResult> Index(string sortBy, string sortOrder)
        {
            var userId = _userManager.GetUserId(User);

            var catalogs = await _context.Catalogs
                .Include(c => c.Furnitures)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            ViewBag.Catalogs = catalogs;


            var furnituresQuery = _context.Furnitures
               .Include(f => f.Brand)
               .Include(f => f.Room)
               .Include(f => f.Colors)
               .Include(f => f.Materials)
               .Include(f => f.FType)
               .AsQueryable();

            // Apply sorting
            switch (sortBy)
            {
                case "name":
                    furnituresQuery = sortOrder == "desc"
                        ? furnituresQuery.OrderByDescending(f => f.Name)
                        : furnituresQuery.OrderBy(f => f.Name);
                    break;

                case "year":
                    furnituresQuery = sortOrder == "desc"
                        ? furnituresQuery.OrderByDescending(f => f.ProductionYear)
                        : furnituresQuery.OrderBy(f => f.ProductionYear);
                    break;

                default:
                    furnituresQuery = furnituresQuery.OrderBy(f => f.Id);
                    break;
            }

            // Execute query
            var furnitures = await furnituresQuery.ToListAsync();

            ViewBag.NameSortOrder = (sortBy == "name" && sortOrder == "asc") ? "asc" : "desc";
            ViewBag.YearSortOrder = (sortBy == "year" && sortOrder == "asc") ? "asc" : "desc";

            return View(furnitures);
        }

        // GET: Underprivileged/Furnitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);

            var catalogs = await _context.Catalogs
                .Include(c => c.Furnitures)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            ViewBag.Catalogs = catalogs;

            var furniture = await _context.Furnitures
                .Include(f => f.Brand)
                .Include(f => f.Room)
                .Include(f => f.Colors)
                .Include(f => f.Materials)
                .Include(f => f.FType)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (furniture == null)
            {
                return NotFound();
            }

            return View(furniture);
        }
    }
}
