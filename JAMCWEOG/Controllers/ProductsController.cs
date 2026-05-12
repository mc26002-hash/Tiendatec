using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using JAMCWEOG.BusinessLogic.Services;
using JAMCWEOG.Entities.Entities;

namespace JAMCWEOG.WebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        private readonly ManufacturerService _manufacturerService;

        public ProductsController(
    ProductService productService,
    ManufacturerService manufacturerService)
        {
            _productService = productService;
            _manufacturerService = manufacturerService;
        }

        // LISTAR
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        // GET CREATE
        public async Task<IActionResult> Create()
        {
            var manufacturers = await _manufacturerService.GetAllAsync();

            ViewBag.ManufacturerId =
                new SelectList(manufacturers, "Id", "Name");

            return View();
        }

        // POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(product);

                return RedirectToAction(nameof(Index));
            }

            var manufacturers = await _manufacturerService.GetAllAsync();

            ViewBag.ManufacturerId =
                new SelectList(manufacturers, "Id", "Name", product.ManufacturerId);

            return View(product);
        }

        // GET EDIT
        public async Task<IActionResult> Edit(long id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var manufacturers = await _manufacturerService.GetAllAsync();

            ViewBag.ManufacturerId =
                new SelectList(manufacturers, "Id", "Name", product.ManufacturerId);

            return View(product);
        }

        // POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }

            var manufacturers = await _manufacturerService.GetAllAsync();

            ViewBag.ManufacturerId =
                new SelectList(manufacturers, "Id", "Name", product.ManufacturerId);

            return View(product);
        }

        // GET DELETE
        public async Task<IActionResult> Delete(long id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _productService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        // DETAILS
        public async Task<IActionResult> Details(long id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}