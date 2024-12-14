using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G5.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Nombre de usuario o email")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; } = string.Empty;
    }
}
