using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G5.Models
{
    public class Categoria
    {
        [Key]
        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        public int Id { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoRequerido)]
        [MaxLength(100, ErrorMessage = ErrorViewModel.CaracteresMaximos)]
        public string Nombre { get; set; }


        [Display(Name = "Descripción")]
        [MaxLength(int.MaxValue, ErrorMessage = ErrorViewModel.CaracteresMaximos)]
        public string Descripcion { get; set; }


        //Relaciones
        //Comentamos el required para que nos deje crear una categoria, sino daba False el "ModelIsValid"
        //[Required(ErrorMessage = ErrorViewModel.CampoRequerido)]   ---> ????
        public List<Producto>? Productos { get; set; }
    }
}
