using Microsoft.EntityFrameworkCore;
using APIBlueLearn.Context;
using APIBlueLearn.Model;



namespace APIBlueLearn.Repositories
{

    public interface IEstadoCultivoRepository
    {
        Task<List<EstadoCultivo>> GetAll();
        Task<EstadoCultivo> GetEstadoCultivo(int IdEstadoCultivo);
        Task<EstadoCultivo> CreateEstadoCultivo(string Descripcion);
        Task<EstadoCultivo> UpdateEstadoCultivo(EstadoCultivo estadoCultivo);
        Task<EstadoCultivo> DeleteEstadoCultivo(EstadoCultivo estadoCultivo);
    }
    public class EstadoCultivoRepository : IEstadoCultivoRepository
    {

        private readonly BLDbContext _db;

        public EstadoCultivoRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<EstadoCultivo> CreateEstadoCultivo(string Descripcion)
        {
            EstadoCultivo newEstadoCultivo = new EstadoCultivo
            {
                Descripcion = Descripcion
            };
            await _db.EstadoCultivo.AddAsync(newEstadoCultivo);
            _db.SaveChanges();
            return newEstadoCultivo;
        }

        /*public async Task<EstadoCultivo> DeleteEstadoCultivo(EstadoCultivo estadoCultivo)
        {
            await _db.EstadoCultivo.AddAsync(estadoCultivo);
            _db.SaveChanges();
            return estadoCultivo;
        }*/
        public async Task<EstadoCultivo> DeleteEstadoCultivo(EstadoCultivo estadoCultivo)
        {
            _db.EstadoCultivo.Attach(estadoCultivo); //Llamamos la actualizacion
            _db.Entry(estadoCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return estadoCultivo;
        }

        public async Task<EstadoCultivo> GetEstadoCultivo(int IdEstadoCultivo)
        {
            return await _db.EstadoCultivo.FirstOrDefaultAsync(e => e.IdEstadoCultivo == IdEstadoCultivo);
        }

        public async Task<List<EstadoCultivo>> GetAll()
        {
            return await _db.EstadoCultivo.ToListAsync();
        }

        public async Task<EstadoCultivo> UpdateEstadoCultivo(EstadoCultivo estadoCultivo)
        {
            EstadoCultivo ConsultUpdate = await _db.EstadoCultivo.FindAsync(estadoCultivo.IdEstadoCultivo);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Descripcion = estadoCultivo.Descripcion;


                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}
