using System.ComponentModel.DataAnnotations;

namespace APIBlueLearn.Model
{
    public class EstadoCultivo
    {

        [Key]
        public int IdEstadoCultivo { get; set; }
        public required string Descripcion { get; set; }
        public bool Eliminado { get; set; }
    }
}
