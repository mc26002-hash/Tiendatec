using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JAMCWEOG.BusinessLogic.Services;
using JAMCWEOG.Entities.Entities;

namespace JAMCWEOG.WebApplication.Controllers
{
    [Authorize]
    public class ManufacturersController : Controller
    {
        private readonly ManufacturerService _manufacturerService;

        public ManufacturersController(ManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        // LISTAR
        public async Task<IActionResult> Index()
        {
            var manufacturers = await _manufacturerService.GetAllAsync();
            return View(manufacturers);
        }

        // GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                await _manufacturerService.AddAsync(manufacturer);
                return RedirectToAction(nameof(Index));
            }

            return View(manufacturer);
        }

        // GET EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var manufacturer = await _manufacturerService.GetByIdAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                await _manufacturerService.UpdateAsync(manufacturer);
                return RedirectToAction(nameof(Index));
            }

            return View(manufacturer);
        }

        // GET DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var manufacturer = await _manufacturerService.GetByIdAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _manufacturerService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var manufacturer = await _manufacturerService.GetByIdAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }
    }
}