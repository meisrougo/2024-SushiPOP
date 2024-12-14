namespace _2024_2C_SushiPOP_G5.Models

{
    using System.ComponentModel.DataAnnotations;

    public class Pedido
    {
        [Key]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Id { get; set; }


        [Display(Name = "Número de pedido")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int NroPedido { get; set; }


        [Display(Name = "Fecha de compra")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public DateTime FechaCompra { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public decimal Subtotal { get; set; }


        [Display(Name = "Gasto del envío")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public decimal GastoEnvio { get; set; } = 80;


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public decimal Total {  get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Estado { get; set; } = 1;
        

        //Relaciones
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]  
        public int CarritoId {  get; set; }
        public Carrito? Carrito { get; set; }

        public Reclamo? Reclamo { get; set; }
    }
}
