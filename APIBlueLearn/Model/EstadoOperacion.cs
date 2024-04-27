using System.ComponentModel.DataAnnotations;

namespace APIBlueLearn.Model
{
    public class EstadoOperacion
    {

        [Key]
        public int IdEstadoOperacion { get; set; }
        public required string Descripcion { get; set; }
        public bool Eliminado { get; set; }
    }
}
