using System.ComponentModel.DataAnnotations;

namespace APIBlueLearn.Model
{
    public class Agricultores
    {
        [Key]
        public int IdAgricultor { get; set; }
        public required int IdJugador { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required string Direccion { get; set; }
        public required string Contacto { get; set; }
        public bool Eliminado { get; set; }
        public Jugador? Jugador { get; set; }

    }
}
