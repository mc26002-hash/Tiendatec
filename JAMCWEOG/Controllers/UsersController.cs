using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using JAMCWEOG.BusinessLogic.Services;
using JAMCWEOG.Entities.Entities;

namespace JAMCWEOG.WebApplication.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;

        public UsersController(UserService userService, RoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        // LISTAR
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllAsync();
            return View(users);
        }

        // GET CREATE
        public async Task<IActionResult> Create()
        {
            var roles = await _roleService.GetAllAsync();

            ViewBag.RoleId = new SelectList(roles, "Id", "Name");

            return View();
        }

        // POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userService.AddAsync(user);

                    return RedirectToAction(nameof(Index));
                }

                // Mostrar errores en consola
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Recargar roles para el ComboBox
            var roles = await _roleService.GetAllAsync();

            ViewBag.RoleId = new SelectList(roles, "Id", "Name", user.RoleId);

            return View(user);
        }

        // GET EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await _roleService.GetAllAsync();

            ViewBag.RoleId = new SelectList(roles, "Id", "Name", user.RoleId);

            return View(user);
        }

        // POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateAsync(user);

                return RedirectToAction(nameof(Index));
            }

            var roles = await _roleService.GetAllAsync();

            ViewBag.RoleId = new SelectList(roles, "Id", "Name", user.RoleId);

            return View(user);
        }

        // GET DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
    }
}