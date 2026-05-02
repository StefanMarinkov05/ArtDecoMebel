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
using Microsoft.AspNetCore.Authorization;

namespace ArtDecoMebel.Areas.Underprivileged.Controllers
{
    [Authorize]
    [Area("Underprivileged")]
    public class CatalogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CatalogsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Underprivileged/Catalogs
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            var catalogs = _context.Catalogs.
                Include(c => c.ApplicationUser).
                Where(c => c.UserId == userId).
                Include(f => f.Furnitures)
                    .ThenInclude(ft => ft.FType);

            return View(await catalogs.ToListAsync());
        }

        // GET: Underprivileged/Catalogs/Details/5
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

        // GET: Underprivileged/Catalogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Underprivileged/Catalogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Underprivileged/Catalogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Catalog catalog)
        {
            var userId = _userManager.GetUserId(User);

            catalog.UserId = userId;

            ModelState.Remove(nameof(catalog.UserId));
            ModelState.Remove(nameof(catalog.ApplicationUser));

            if (ModelState.IsValid)
            {

                _context.Add(catalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }

            // If we reached here, 'Name' was likely invalid.
            return View(catalog);
        }

        // GET: Underprivileged/Catalogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalogs.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", catalog.UserId);
            return RedirectToAction(nameof(Index));
        }

        // POST: Underprivileged/Catalogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // Inside Underprivileged/CatalogsController.cs

        // POST: Underprivileged/Catalogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Name")] Catalog catalog)
        {
            if (id != catalog.Id)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);

            ModelState.Remove(nameof(catalog.ApplicationUser));

            if (ModelState.IsValid)
            {

                _context.Update(catalog);
                await _context.SaveChangesAsync();                
                return RedirectToAction(nameof(Details), new { id = catalog.Id });
            }

            var fullCatalog = await _context.Catalogs
                .Include(c => c.ApplicationUser)
                .Include(c => c.Furnitures)
                .ThenInclude(ft => ft.FType)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (fullCatalog == null) return NotFound();

            fullCatalog.Name = catalog.Name;
            return View(nameof(Details), fullCatalog);
        }

        // GET: Underprivileged/Catalogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            return RedirectToAction(nameof(Index));
        }

        // POST: Underprivileged/Catalogs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = _userManager.GetUserId(User);

            var catalog = await _context.Catalogs.FindAsync(id);

            if (catalog != null)
            {
                _context.Catalogs.Remove(catalog);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddFurniture(int catalogId, int furnitureId)
        {
            var cat = await _context.Catalogs
                .Include(c => c.Furnitures)
                .ThenInclude(ft => ft.FType)
                .FirstOrDefaultAsync(c => c.Id == catalogId);

            if (cat == null) return NotFound();

            var furn = await _context.Furnitures.FindAsync(furnitureId);
            if (furn == null) return NotFound();

            if (!cat.Furnitures.Any(f => f.Id == furnitureId))
            {
                cat.Furnitures.Add(furn);
                await _context.SaveChangesAsync();
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFurniture(int catalogId, int furnitureId)
        {
            var cat = await _context.Catalogs
                .Include(c => c.Furnitures)
                .ThenInclude(ft => ft.FType)
                .FirstOrDefaultAsync(c => c.Id == catalogId);

            if (cat == null) return NotFound();

            var furn = cat.Furnitures.FirstOrDefault(f => f.Id == furnitureId);
            if (furn != null)
            {
                cat.Furnitures.Remove(furn);
                await _context.SaveChangesAsync();
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}
