using ArtDecoMebel;
using ArtDecoMebel.Configuration;
using ArtDecoMebel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtDecoMebel.Areas.Privileged.Controllers
{
    [Authorize(Roles = AppConfiguration.PrivilegedRoleString)]
    [Area("Privileged")]
    public class CatalogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CatalogsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Privileged/Catalogs
        public async Task<IActionResult> Index()
        {
            var catalogs = _context.Catalogs.
                Include(c => c.ApplicationUser).
                Include(f => f.Furnitures)
                .ThenInclude(ft => ft.FType);

            return View(await catalogs.ToListAsync());
        }

        // GET: Privileged/Catalogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalogs
                .Include(c => c.ApplicationUser)
                .Include(f => f.Furnitures)
                .ThenInclude(ft => ft.FType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }


        // POST: Privileged/Catalogs/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalog = await _context.Catalogs.FindAsync(id);
            if (catalog != null)
            {
                _context.Catalogs.Remove(catalog);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
