using System.ComponentModel.DataAnnotations;

namespace APIBlueLearn.Model
{
    public class Campos
    {
        [Key]
        public int IdCampo { get; set; }
        public required string NombreCampo { get; set; }
        public required string Ubicacion { get; set; }
        public required int Tamano { get; set; }
        public bool Eliminado { get; set; }

    }
}
