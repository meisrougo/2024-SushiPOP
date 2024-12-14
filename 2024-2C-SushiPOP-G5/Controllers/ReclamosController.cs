using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2024_2C_SushiPOP_G5.Models;
using Microsoft.AspNetCore.Authorization;

namespace _2024_2C_SushiPOP_G5.Controllers
{
    public class ReclamosController : Controller
    {
        private readonly DbContext _context;

        public ReclamosController(DbContext context)
        {
            _context = context;
        }

        // GET: Reclamos
        [Authorize(Roles = "EMPLEADO")]
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.Reclamo.Include(r => r.Pedido);
            return View(await dbContext.ToListAsync());
        }

        // GET: Reclamos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamo = await _context.Reclamo
                .Include(r => r.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reclamo == null)
            {
                return NotFound();
            }

            return View(reclamo);
        }

        // GET: Reclamos/Create
        [Authorize(Roles = "CLIENTE")]
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id");
            return View();
        }

        // POST: Reclamos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CLIENTE")]
        public async Task<IActionResult> Create([Bind("Id,NombreCompleto,Email,Telefono,DetalleReclamo,PedidoId")] Reclamo reclamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reclamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "Id", "Id", reclamo.PedidoId);
            return View(reclamo);
        }

        

        private bool ReclamoExists(int id)
        {
            return _context.Reclamo.Any(e => e.Id == id);
        }
    }
}
