using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G5.Models
{
    public class Descuento
    {
        [Key]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Id { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }


        [Display(Name = "Día")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [StringLength(7, MinimumLength = 1, ErrorMessage = ErrorViewModel.CaracteresMinimosMaximos)]
        public int Dia { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Porcentaje { get; set; } = 0;


        [Display(Name = "Descuento maximo")]
        public decimal DescuentoMax { get; set; } = 1000;


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public bool Activo { get; set; } = true;
    }
}

