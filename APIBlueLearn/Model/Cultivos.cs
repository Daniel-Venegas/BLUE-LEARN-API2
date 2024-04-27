using System.ComponentModel.DataAnnotations;

namespace APIBlueLearn.Model
{
    public class Cultivos
    {

        [Key]
        public int IdCultivo { get; set; }
        public required DateTime FechaPlantacion { get; set; }
        public required int IdEstadoCultivo { get; set; }
        public required int IdCampo { get; set; }
        public bool Eliminado { get; set; }
        public Campos? Campos { get; set; }
        public EstadoCultivo? EstadoCultivo { get; set; }
    }
}
