namespace _2024_2C_SushiPOP_G5.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Reclamo
    {
        [Key]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Id { get; set; }


        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [StringLength(255, ErrorMessage = ErrorViewModel.CaracteresMaximos)]
        public string NombreCompleto { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public string Email { get; set; }


        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [StringLength(10, MinimumLength = 10, ErrorMessage = ErrorViewModel.CaracteresExactos)]
        public string Telefono { get; set; }


        [Display(Name = "Detalle del reclamo")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [StringLength(int.MaxValue, MinimumLength = 50, ErrorMessage = ErrorViewModel.CaracteresMinimosMaximos)]
        public string DetalleReclamo { get; set; }


        /*
        * Relaciones
        */
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }
    }
}


