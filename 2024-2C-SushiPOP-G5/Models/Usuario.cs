using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2024_2C_SushiPOP_G5.Models
{
    public abstract class Usuario
    {
        [Key]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Id { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = ErrorViewModel.CaracteresMinimosMaximos)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = ErrorViewModel.CaracteresMinimosMaximos)]
        public string Apellido { get; set; }


        [Display(Name = "Dirección")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [MaxLength(100, ErrorMessage = ErrorViewModel.CaracteresMaximos)]
        public string Direccion { get; set; }


        [Display(Name = "Telefóno")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [StringLength(10, MinimumLength = 10, ErrorMessage = ErrorViewModel.CaracteresExactos)]
        public string Telefono { get; set; }


        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public DateTime FechaDeNacimiento { get; set; }


        [Display(Name = "Fecha de alta")]
        public DateTime FechaAlta { get; set; }



        public bool Activo { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public string Email { get; set; }


        [NotMapped]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }
}
    }
