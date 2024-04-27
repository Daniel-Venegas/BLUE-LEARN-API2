using APIBlueLearn.Model;
using Microsoft.EntityFrameworkCore;

namespace APIBlueLearn.Context
{
    public class BLDbContext : DbContext
    {

        public BLDbContext(DbContextOptions<BLDbContext> options) : base(options)
        {
        }
        public DbSet<OperacionesCultivo> OpeCultivos { get; set; }
        public DbSet<Cultivos> Cultivos { get; set; }

        public DbSet<EstadoOperacion> EstadoOperacion { get; set; }
        public DbSet<Agricultores> Agricultores { get; set; }

        public DbSet<Jugador> Jugador { get; set; }
        public DbSet<Partida> Partida { get; set; }
        public DbSet<Logro> Logro { get; set; }
        public DbSet<Monitoreo> Monitoreo { get; set; }
        public DbSet<DescripcionMonitoreo> DescripcionMonitoreo { get; set; }
        public DbSet<Campos> Campos { get; set; }
        public DbSet<EstadoCultivo> EstadoCultivo { get; set; }

        public DbSet<Cosechas> Cosechas { get; set; }
        public DbSet<Temporadas> Temporadas { get; set; }
        public DbSet<EtapaAprendizaje> EtapaAprendizaje { get; set; }
        public DbSet<Etapa> Etapa { get; set; }
    }
}
