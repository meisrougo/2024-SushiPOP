using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G5.Models
{
    public class Cliente : Usuario
    {
        public int NumeroCliente { get; set; }


        //
        //Relaciones//
        //
        public List<Reserva>? Reservas { get; set; }
        public List<Carrito>? Carritos { get; set; }
    }
}
