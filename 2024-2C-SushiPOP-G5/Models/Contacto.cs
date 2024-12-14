using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G5.Models
{

    public class Contacto
    {
        [Key]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Id { get; set; }


        [Display(Name = "Nombre completo")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [StringLength(255, ErrorMessage = ErrorViewModel.CaracteresMaximos)]
        public string NombreCompleto { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public string Email { get; set; }


        [Display(Name = "Teléfono")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = ErrorViewModel.CaracteresExactos)]
        public string Telefono { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [StringLength(int.MaxValue, ErrorMessage = ErrorViewModel.CaracteresMaximos)]
        public string Mensaje { get; set; }


        [Display(Name = "Leído")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public bool Leido { get; set; } = false;
    }
}

