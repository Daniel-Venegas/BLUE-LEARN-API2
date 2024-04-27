using System.ComponentModel.DataAnnotations;

namespace APIBlueLearn.Model
{
    public class Monitoreo
    {
        [Key]
        public int IdMonitoreo { get; set; }
        public required DateTime FechaMonitoreo { get; set; }
        public required int Valor { get; set; }
        public required int IdDescripcionMonitoreo { get; set; }
        public required int IdCultivo { get; set; }
        public bool Eliminado { get; set; }
        public Cultivos? Cultivos { get; set; }
        public DescripcionMonitoreo? DescripcionMonitoreo { get; set; }
    }
}
