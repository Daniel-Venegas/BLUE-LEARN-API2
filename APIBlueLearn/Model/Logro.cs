using System.ComponentModel.DataAnnotations;

namespace APIBlueLearn.Model
{
    public class Logro
    {

        [Key]
        public int IdLogro { get; set; }
        public required string Descripcion { get; set; }
        public required DateTime Fecha { get; set; }
        public required int Puntos { get; set; }
        public bool Eliminado { get; set; }
    }
}
