using _2024_2C_SushiPOP_G5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2024_2C_SushiPOP_G5.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager; // Agregado
        private readonly DbContext _context;

        public LoginController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager, // Agregado
            DbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager; // Asignado
            _context = context;
        }

        // GET: Iniciar Sesión
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IniciarSesion([Bind("Email,Clave")] LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.Email, login.Clave, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Inicio de sesión inválido.");
                }
            }
            return View(login);
        }

        [Authorize]
        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Perfil()
        {
            var userEmail = User.Identity.Name;

            if (User.IsInRole("ADMIN"))
            {
                // Mostrar mensaje para administradores
                ViewBag.Message = "Cuenta de Administrador";
                return View("PerfilAdmin");
            }
            else if (User.IsInRole("EMPLEADO"))
            {
                var empleado = await _context.Set<Empleado>().FirstOrDefaultAsync(e => e.Email == userEmail);
                if (empleado == null)
                {
                    return NotFound("Empleado no encontrado");
                }

                // Mostrar vista del perfil del empleado
                return View("PerfilEmpleado", empleado);
            }
            else if (User.IsInRole("CLIENTE"))
            {
                var cliente = await _context.Set<Cliente>().FirstOrDefaultAsync(c => c.Email == userEmail);
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                // Mostrar vista del perfil del cliente
                return View("PerfilCliente", cliente);
            }

            // Caso predeterminado: redirigir al Home si no hay un rol válido
            return RedirectToAction("Index", "Home");
        }

       
    }
}
