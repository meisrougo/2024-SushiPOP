using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2024_2C_SushiPOP_G5.Models;
using Microsoft.AspNetCore.Identity;

namespace _2024_2C_SushiPOP_G5.Controllers
{
    public class CarritoItemsController : Controller
    {
        private readonly DbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CarritoItemsController(DbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

     
        // POST: CarritoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("ProductoId, Cantidad")] ItemViewModel carritoItem)

        {
            if (ModelState.IsValid)
            {
                Producto producto = await _context.Producto.FindAsync(carritoItem.ProductoId);

                if (producto == null || producto.Stock < carritoItem.Cantidad)
                {
                    return NotFound();
                }
                              
                var usuarioLogueado = await _userManager.GetUserAsync(User);

                Cliente cliente = await _context.Cliente.FirstOrDefaultAsync(cliente => cliente.Email == usuarioLogueado.Email);

                Carrito carrito = await _context.Carrito
                    .Include(Carrito => Carrito.Cliente)
                    .Include(Carrito => Carrito.CarritoItems)
                    .ThenInclude(carritoItem => carritoItem.Producto)
                    .FirstOrDefaultAsync(carrito => !carrito.Procesado && !carrito.Cancelado && carrito.Cliente.Email == usuarioLogueado.Email);

                //Veo si el cliente tiene un carrito
                if (carrito == null)
                {
                    //Creamos el carrito
                    carrito = new();
                    carrito.Procesado = false;
                    carrito.ClienteId = cliente.Id;
                    carrito.CarritoItems = [];

                    _context.Add(carrito);
                    await _context.SaveChangesAsync();

                    //Creamos el item

                    CarritoItem item = new();
                    item.PrecioUnitConDto = producto.Precio;
                    item.Cantidad = carritoItem.Cantidad;
                    item.ProductoId = producto.Id;
                    item.CarritoId = carrito.Id;

                    _context.Add(item);
                    await _context.SaveChangesAsync();
                }
                else

                {
                    //Buscar si el producto esta en el carrito 
                    CarritoItem itemBuscado = carrito.CarritoItems.FirstOrDefault(carritoItemBuscado => carritoItemBuscado.ProductoId == carritoItem.ProductoId);

                    if(itemBuscado == null)
                    {
                        itemBuscado = new();
                        itemBuscado.PrecioUnitConDto = producto.Precio;
                        itemBuscado.Cantidad = carritoItem.Cantidad;
                        itemBuscado.ProductoId = producto.Id;
                        itemBuscado.CarritoId = carrito.Id;

                        _context.Add(itemBuscado);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {

                        itemBuscado.Cantidad += carritoItem.Cantidad;
                        _context.Update(itemBuscado);
                        await _context.SaveChangesAsync();
                    }

                }

                //Modificar stock del producto
                producto.Stock -= carritoItem.Cantidad;
                _context.Update(producto);
                await _context.SaveChangesAsync();
                

            }
            return RedirectToAction("Index", "Carritos");
        }

    }
}
