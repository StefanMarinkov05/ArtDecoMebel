using ArtDecoMebel.Configuration;
using ArtDecoMebel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtDecoMebel.Areas.Privileged.Controllers
{
    [Authorize(Roles = AppConfiguration.PrivilegedRoleString)]
    [Area("Privileged")]
    public class FTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Privileged/FTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FTypes.ToListAsync());
        }

        // GET: Privileged/FTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Privileged/FTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FType fType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fType);
        }

        // GET: Privileged/FTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fType = await _context.FTypes.FindAsync(id);
            if (fType == null)
            {
                return NotFound();
            }
            return View(fType);
        }

        // POST: Privileged/FTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FType fType)
        {
            if (id != fType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FTypeExists(fType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fType);
        }

        // GET: Privileged/FTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fType = await _context.FTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fType == null)
            {
                return NotFound();
            }

            return View(fType);
        }

        // POST: Privileged/FTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fType = await _context.FTypes.FindAsync(id);
            if (fType != null)
            {
                _context.FTypes.Remove(fType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FTypeExists(int id)
        {
            return _context.FTypes.Any(e => e.Id == id);
        }
    }
}
