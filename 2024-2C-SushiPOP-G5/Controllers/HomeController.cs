using _2024_2C_SushiPOP_G5.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _2024_2C_SushiPOP_G5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, DbContext context, UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {            
            if (!_roleManager.RoleExistsAsync("ADMIN").GetAwaiter().GetResult())
            {
                // Creación de roles
                _roleManager.CreateAsync(new IdentityRole("ADMIN")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("EMPLEADO")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("CLIENTE")).GetAwaiter().GetResult();

                // Creación del ADMIN
                IdentityUser user = new IdentityUser();
                user.Email = user.UserName = "admin@ort.edu.ar";
                IdentityResult result = await _userManager.CreateAsync(user, "Password1!");

                // Creación del EMPLEADO MOMENTANEAMENTE (Esto a modo de prueba para testear el CREATE de producto y categoria) ----> ????
                IdentityUser user1 = new IdentityUser();
                user1.Email = user1.UserName = "empleado@ort.edu.ar";
                IdentityResult result1 = await _userManager.CreateAsync(user1, "Password1!");

                if (result.Succeeded && result1.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "ADMIN");
                    await _userManager.AddToRoleAsync(user1, "EMPLEADO");
                }
            }

            var categorias = await _context.Set<Categoria>().ToListAsync();
            ViewBag.Categorias = categorias;

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
