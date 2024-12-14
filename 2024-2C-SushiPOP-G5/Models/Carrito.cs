using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G5.Models
{
    public class Carrito
    {
        [Key]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public bool Procesado { get; set; } = false;

        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public bool Cancelado { get; set; } = false;


        /*
         * Relaciones
         */
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public List<CarritoItem>? CarritoItems { get; set; }

        public Pedido? Pedido { get; set; }
    }
}
