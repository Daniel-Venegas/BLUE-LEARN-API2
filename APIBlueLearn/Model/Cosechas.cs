using System.ComponentModel.DataAnnotations;

namespace APIBlueLearn.Model
{
    public class Cosechas
    {

        [Key]
        public int IdCosechas { get; set; }
        public required DateTime FechaCosecha { get; set; }
        public required int CantidadRecogida { get; set; }
        public required int IdCultivo { get; set; }
        public required int IdTemporada { get; set; }

        public bool Eliminado { get; set; }
        public Cultivos? Cultivos { get; set; }
        public Temporadas? Temporadas { get; set; }
    }
}
