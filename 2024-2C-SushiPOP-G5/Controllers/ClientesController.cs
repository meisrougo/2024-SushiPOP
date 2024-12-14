using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2024_2C_SushiPOP_G5.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace _2024_2C_SushiPOP_G5.Controllers
{
    public class ClientesController : Controller
    {
        private readonly DbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ClientesController(DbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Clientes
        [Authorize(Roles = "EMPLEADO")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View(); //return RedirectToAction("Index", "Home");

        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Direccion,Telefono,FechaDeNacimiento,Email,Clave")] Cliente cliente)
        {
            cliente.FechaAlta = DateTime.Now;
            cliente.Activo = true;
            cliente.NumeroCliente = 1;

            if (ModelState.IsValid)
            {
                //Cliente en Identity
                //Agregue el rol de Cliente
                IdentityUser user = new()
                {
                    Email = cliente.Email,
                    UserName = cliente.Email
                };

                IdentityResult result = await _userManager.CreateAsync(user, cliente.Clave);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "CLIENTE");

                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                   return RedirectToAction("Index", "Home");
                }
            }
            return View(cliente);

        }


        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}
