namespace _2024_2C_SushiPOP_G5.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public const string CampoRequerido = "{0} es un campo obligatorio.";
        public const string CaracteresMaximos = "{0} no debe superar los {1} caracteres.";
        public const string CaracteresMinimosMaximos = "{0} debe tener entre {2} y {1} caracteres.";
        public const string CaracteresExactos = "{0} debe tener exactamente {1} caracteres.";
    }
}
