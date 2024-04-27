using System.ComponentModel.DataAnnotations;

namespace APIBlueLearn.Model
{
    public class Partida
    {
        [Key]
        public int IdPartida { get; set; }
        public required string NombrePartida { get; set; }
        public required int IdJugador { get; set; }
        public required int IdLogro { get; set; }
        public required int PuntajePartida { get; set; }
        public bool Eliminado { get; set; }
        public Jugador? Jugador { get; set; }
        public Logro? Logro { get; set; }
    }
}
