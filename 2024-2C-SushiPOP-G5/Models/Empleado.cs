using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G5.Models
{
    
    public class Empleado : Usuario
    {
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Legajo { get; set; } = 99000;//consultar logica legajo
    }
}


