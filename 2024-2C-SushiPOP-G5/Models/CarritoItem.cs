using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G5.Models
{
    public class CarritoItem
    {
        [Key]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Id { get; set; }

      
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [Display(Name = "Precio unitario con descuento")]
        public decimal PrecioUnitConDto { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Cantidad { get; set; }

        /*
        * Relaciones
        */
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int CarritoId { get; set; }
        public Carrito? Carrito { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int ProductoId  { get; set; }
        public Producto? Producto { get; set; }
    }
}
