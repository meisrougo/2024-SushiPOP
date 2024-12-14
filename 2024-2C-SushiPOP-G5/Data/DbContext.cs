using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _2024_2C_SushiPOP_G5.Models;

    public class DbContext : IdentityDbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<_2024_2C_SushiPOP_G5.Models.Carrito> Carrito { get; set; } = default!;

public DbSet<_2024_2C_SushiPOP_G5.Models.CarritoItem> CarritoItem { get; set; } = default!;

public DbSet<_2024_2C_SushiPOP_G5.Models.Categoria> Categoria { get; set; } = default!;

public DbSet<_2024_2C_SushiPOP_G5.Models.Cliente> Cliente { get; set; } = default!;

public DbSet<_2024_2C_SushiPOP_G5.Models.Contacto> Contacto { get; set; } = default!;

public DbSet<_2024_2C_SushiPOP_G5.Models.Descuento> Descuento { get; set; } = default!;

public DbSet<_2024_2C_SushiPOP_G5.Models.Empleado> Empleado { get; set; } = default!;

public DbSet<_2024_2C_SushiPOP_G5.Models.Pedido> Pedido { get; set; } = default!;

public DbSet<_2024_2C_SushiPOP_G5.Models.Producto> Producto { get; set; } = default!;

public DbSet<_2024_2C_SushiPOP_G5.Models.Reclamo> Reclamo { get; set; } = default!;

public DbSet<_2024_2C_SushiPOP_G5.Models.Reserva> Reserva { get; set; } = default!;
    }
