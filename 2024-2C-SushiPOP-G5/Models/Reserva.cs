namespace _2024_2C_SushiPOP_G5.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Reserva
    {
        [Key]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Id {  get; set; }


        [Required (ErrorMessage = ErrorViewModel.CampoRequerido)]
        public string Local { get; set; }


        [Display(Name = "Fecha y hora")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public DateTime FechaHora { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public bool Confirmada { get; set; } = false;


        //Nombre y Apellido se especifica?

        //Relaciones [FK]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)] 
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
