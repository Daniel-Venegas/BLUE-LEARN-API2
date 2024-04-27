using System.ComponentModel.DataAnnotations;

namespace APIBlueLearn.Model
{
    public class OperacionesCultivo
    {
        [Key]
        public int IdOperacion { get; set; }
        public required int IdEstadoOperacion { get; set; }
        public required DateTime FechaOperacion { get; set; }
        public required string Descripcion { get; set; }
        public required int IdCultivo { get; set; }
        public required int IdAgricultor { get; set; }
        public bool Eliminado { get; set; }
        public Cultivos? Cultivos { get; set; }
        public EstadoOperacion? EstadoOperacion { get; set; }
        public Agricultores? Agricultores { get; set; }
    }
}
