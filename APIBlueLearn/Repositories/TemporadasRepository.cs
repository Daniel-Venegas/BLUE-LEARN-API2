using Microsoft.EntityFrameworkCore;
using APIBlueLearn.Context;
using APIBlueLearn.Model;

namespace APIBlueLearn.Repositories
{
    public interface ITemporadasRepository
    {
        Task<List<Temporadas>> GetAll();
        Task<Temporadas> GetTemporadas(int IdTemporada);
        Task<Temporadas> CreateTemporadas(string Temporada);
        Task<Temporadas> UpdateTemporadas(Temporadas temporadas);
        Task<Temporadas> DeleteTemporadas(Temporadas temporadas);
    }
    public class TemporadasRepository : ITemporadasRepository
    {

        private readonly BLDbContext _db;

        public TemporadasRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<Temporadas> CreateTemporadas(string Temporada)
        {
            Temporadas newTemporadas = new Temporadas
            {
                Temporada = Temporada
            };
            await _db.Temporadas.AddAsync(newTemporadas);
            _db.SaveChanges();
            return newTemporadas;
        }

        /*public async Task<Temporadas> DeleteTemporadas(Temporadas temporadas)
        {
            await _db.Temporadas.AddAsync(temporadas);
            _db.SaveChanges();
            return temporadas;
        }*/

        public async Task<Temporadas> DeleteTemporadas(Temporadas temporadas)
        {
            _db.Temporadas.Attach(temporadas); //Llamamos la actualizacion
            _db.Entry(temporadas).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return temporadas;
        }

        public async Task<List<Temporadas>> GetAll()
        {
            return await _db.Temporadas.ToListAsync();
        }

        public async Task<Temporadas> GetTemporadas(int IdTemporada)
        {
            return await _db.Temporadas.FirstOrDefaultAsync(e => e.IdTemporada == IdTemporada);
        }

        public async Task<Temporadas> UpdateTemporadas(Temporadas temporadas)
        {
            Temporadas ConsultUpdate = await _db.Temporadas.FindAsync(temporadas.IdTemporada);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Temporada = temporadas.Temporada;


                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}
