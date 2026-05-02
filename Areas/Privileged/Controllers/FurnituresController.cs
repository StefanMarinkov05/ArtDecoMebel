using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtDecoMebel.Models;
using Microsoft.AspNetCore.Authorization;
using ArtDecoMebel.Configuration;

namespace ArtDecoMebel.Areas.Privileged.Controllers
{
    [Authorize(Roles = AppConfiguration.PrivilegedRoleString)]
    [Area("Privileged")]
    public class FurnituresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FurnituresController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Privileged/Furnitures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Furnitures
                .Include(f => f.Brand)
                .Include(f => f.Room)
                .Include(f => f.FType) 
                .Include(f => f.Colors)
                .Include(f => f.Materials);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Privileged/Furnitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var furniture = await _context.Furnitures
                .Include(f => f.Brand)
                .Include(f => f.Room)
                .Include(f => f.FType)
                .Include(f => f.Colors)
                .Include(f => f.Materials)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (furniture == null) return NotFound();

            return View(furniture);
        }

        // GET: Privileged/Furnitures/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name");
            ViewData["TypeId"] = new SelectList(_context.FTypes, "Id", "Name");
            ViewData["ColorIds"] = new MultiSelectList(_context.Colors, "Id", "Name");
            ViewData["MaterialIds"] = new MultiSelectList(_context.Materials, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Furniture furniture, int[] ColorIds, int[] MaterialIds)
        {
            // Remove navigation properties from validation
            ModelState.Remove(nameof(furniture.Brand));
            ModelState.Remove(nameof(furniture.Room));
            ModelState.Remove(nameof(furniture.FType));
            ModelState.Remove(nameof(furniture.Colors));
            ModelState.Remove(nameof(furniture.Materials));
            ModelState.Remove(nameof(furniture.Photo));

            if (ModelState.IsValid)
            {
                if (ColorIds != null)
                {
                    furniture.Colors = await _context.Colors.Where(c => ColorIds.Contains(c.Id)).ToListAsync();
                }

                if (MaterialIds != null)
                {
                    furniture.Materials = await _context.Materials.Where(m => MaterialIds.Contains(m.Id)).ToListAsync();
                }

                _context.Add(furniture);
                await _context.SaveChangesAsync();

                if (furniture.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string extension = Path.GetExtension(furniture.ImageFile.FileName);
                    string fileName = "furniture" + furniture.Id + extension;
                    string path = Path.Combine(wwwRootPath, "Mebeli", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await furniture.ImageFile.CopyToAsync(fileStream);
                    }

                    furniture.Photo = fileName;
                    _context.Update(furniture);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            PopulateViewData(furniture, ColorIds, MaterialIds);
            return View(furniture);
        }

        // GET: Privileged/Furnitures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var furniture = await _context.Furnitures
                .Include(f => f.Colors)
                .Include(f => f.Materials)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (furniture == null) return NotFound();

            PopulateViewData(furniture, furniture.Colors.Select(c => c.Id), furniture.Materials.Select(m => m.Id));
            return View(furniture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Furniture furniture, int[] ColorIds, int[] MaterialIds)
        {
            if (id != furniture.Id) return NotFound();

            ModelState.Remove(nameof(furniture.Brand));
            ModelState.Remove(nameof(furniture.Room));
            ModelState.Remove(nameof(furniture.FType));
            ModelState.Remove(nameof(furniture.Colors));
            ModelState.Remove(nameof(furniture.Materials));
            ModelState.Remove(nameof(furniture.Photo));

            if (ModelState.IsValid)
            {
                var furnitureToUpdate = await _context.Furnitures
                    .Include(f => f.Colors)
                    .Include(f => f.Materials)
                    .FirstOrDefaultAsync(f => f.Id == id);

                if (furnitureToUpdate == null) return NotFound();

                var oldPhoto = furnitureToUpdate.Photo;
                _context.Entry(furnitureToUpdate).CurrentValues.SetValues(furniture);

                // Handle Colors
                furnitureToUpdate.Colors.Clear();
                if (ColorIds != null)
                {
                    var selectedColors = await _context.Colors.Where(c => ColorIds.Contains(c.Id)).ToListAsync();
                    furnitureToUpdate.Colors.AddRange(selectedColors);
                }

                // Handle Materials
                furnitureToUpdate.Materials.Clear();
                if (MaterialIds != null)
                {
                    var selectedMaterials = await _context.Materials.Where(m => MaterialIds.Contains(m.Id)).ToListAsync();
                    furnitureToUpdate.Materials.AddRange(selectedMaterials);
                }

                // Handle Image
                if (furniture.ImageFile != null)
                {
                    string imagesPath = Path.Combine(_hostEnvironment.WebRootPath, "Mebeli");
                    if (!string.IsNullOrEmpty(oldPhoto))
                    {
                        var oldFilePath = Path.Combine(imagesPath, oldPhoto);
                        if (System.IO.File.Exists(oldFilePath)) System.IO.File.Delete(oldFilePath);
                    }

                    string extension = Path.GetExtension(furniture.ImageFile.FileName);
                    string newFileName = "furniture" + id + extension;
                    using (var fileStream = new FileStream(Path.Combine(imagesPath, newFileName), FileMode.Create))
                    {
                        await furniture.ImageFile.CopyToAsync(fileStream);
                    }
                    furnitureToUpdate.Photo = newFileName;
                }
                else
                {
                    furnitureToUpdate.Photo = oldPhoto;
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateViewData(furniture, ColorIds, MaterialIds);
            return View(furniture);
        }

        // Shared helper to keep code DRY (Don't Repeat Yourself)
        private void PopulateViewData(Furniture furniture, IEnumerable<int> colorIds, IEnumerable<int> materialIds)
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", furniture.BrandId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", furniture.RoomId);
            ViewData["TypeId"] = new SelectList(_context.FTypes, "Id", "Name", furniture.TypeId);
            ViewData["ColorIds"] = new MultiSelectList(_context.Colors, "Id", "Name", colorIds);
            ViewData["MaterialIds"] = new MultiSelectList(_context.Materials, "Id", "Name", materialIds);
        }

        // GET: Privileged/Furnitures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var furniture = await _context.Furnitures
                .Include(f => f.Brand)
                .Include(f => f.Room)
                .Include(f => f.FType)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (furniture == null) return NotFound();

            return View(furniture);
        }

        // POST: Privileged/Furnitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var furniture = await _context.Furnitures.FindAsync(id);

            if (furniture != null)
            {
                if (!string.IsNullOrEmpty(furniture.Photo))
                {
                    string imagesPath = Path.Combine(_hostEnvironment.WebRootPath, "Mebeli");
                    var filePath = Path.Combine(imagesPath, furniture.Photo);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.Furnitures.Remove(furniture);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool FurnitureExists(int id) => _context.Furnitures.Any(e => e.Id == id);
    }
}