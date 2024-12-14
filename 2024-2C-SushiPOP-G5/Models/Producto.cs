namespace _2024_2C_SushiPOP_G5.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Producto
    {
        [Key]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Id { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [MaxLength(100, ErrorMessage = ErrorViewModel.CaracteresMaximos)]
        public string Nombre { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [StringLength(250, MinimumLength = 20, ErrorMessage = ErrorViewModel.CaracteresMinimosMaximos)]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public decimal Precio { get; set; }


        public string? Foto { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Stock { get; set; } = 100;


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public decimal Costo { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        //Prueba de atributo para manejar la carga de imagenes.
        [NotMapped] // Esto evita que la propiedad se mapee a la base de datos
        public IFormFile? FotoArchivo { get; set; }


        //Relaciones
        public List<Descuento>? Descuentos { get; set; }
        public List<CarritoItem>? Items { get; set; }
    }
}
