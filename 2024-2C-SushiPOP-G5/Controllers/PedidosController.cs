using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2024_2C_SushiPOP_G5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace _2024_2C_SushiPOP_G5.Controllers
{
    public class PedidosController : Controller
    {
        private readonly DbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public PedidosController(DbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Pedidos
        [Authorize(Roles = "CLIENTE, EMPLEADO")]
        public async Task<IActionResult> Index()
        {
            IdentityUser usuarioLogueado = await _userManager.GetUserAsync(User);
            Cliente cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Email == usuarioLogueado.Email);

            IQueryable<Pedido> dbContext;
            if (User.IsInRole("EMPLEADO")) {
                dbContext = _context.Pedido.Include(p => p.Carrito);
            } else {
                dbContext = _context.Pedido.Include(p => p.Carrito)
                    .Where(p => p.Carrito.Cliente.Email == usuarioLogueado.Email);
            }

            return View(await dbContext.ToListAsync());
        }

        public async Task<IActionResult> VerDetalle()
        {
            IdentityUser usuarioLogueado = await _userManager.GetUserAsync(User);
            Cliente cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Email == usuarioLogueado.Email);

            Carrito carrito = await _context.Carrito
            .Include(Carrito => Carrito.Cliente)
            .Include(Carrito => Carrito.CarritoItems)
            .ThenInclude(carritoItem => carritoItem.Producto)
            .FirstOrDefaultAsync(carrito => !carrito.Procesado && !carrito.Cancelado && carrito.Cliente.Email == usuarioLogueado.Email);

            decimal subtotal = carrito.CarritoItems.Sum(x => x.PrecioUnitConDto * x.Cantidad);
            decimal gastoEnvio = 1500;

            PedidoViewModel viewModel = new PedidoViewModel()
            {
                Cliente = cliente.Nombre + " " + cliente.Apellido,
                Subtotal = subtotal,
                GastoEnvio = gastoEnvio,
                Total = subtotal + gastoEnvio

            };


            return View(viewModel);
        }

        public async Task<IActionResult> ConfirmarPedido()
        {
            // Detalle carrito
            IdentityUser usuarioLogueado = await _userManager.GetUserAsync(User);

            Carrito carrito = await _context.Carrito
                .Include(Carrito => Carrito.Cliente)
                .Include(Carrito => Carrito.CarritoItems)
                .ThenInclude(carritoItem => carritoItem.Producto)
                .FirstOrDefaultAsync(Carrito => !Carrito.Procesado && Carrito.Cliente.Email == usuarioLogueado.Email);

            decimal subtotal = carrito.CarritoItems.Sum(x => x.PrecioUnitConDto * x.Cantidad);
            decimal gastoEnvio = 1500; // Valor fijo del costo de envío

            int nroPedido = 30000;
            var pedidoBuscado = await _context.Pedido.OrderByDescending(p => p.Id).FirstOrDefaultAsync();

            if (pedidoBuscado != null)
            {
                nroPedido = pedidoBuscado.NroPedido + 1;
            }

            // Paso 1: crear el pedido
            Pedido pedido = new()
            {
                Subtotal = subtotal,
                GastoEnvio = gastoEnvio,
                Total = subtotal + gastoEnvio,
                FechaCompra = DateTime.Now,
                CarritoId = carrito.Id,
                NroPedido= nroPedido
            };

            // Persistir el pedido
            _context.Add(pedido);
            await _context.SaveChangesAsync();

            // Paso 2: marcar el carrito como procesado
            carrito.Procesado = true;
            _context.Update(carrito);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Pedidos");

        }

    }
}
