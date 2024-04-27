using Microsoft.EntityFrameworkCore;
using APIBlueLearn.Context;
using APIBlueLearn.Model;


namespace APIBlueLearn.Repositories
{

    public interface ILogroRepository
    {
        Task<List<Logro>> GetAll();
        Task<Logro> GetLogro(int IdLogro);
        Task<Logro> CreateLogro(string Descripcion, DateTime Fecha, int Puntos);
        Task<Logro> UpdateLogro(Logro logro);
        Task<Logro> DeleteLogro(Logro logro);
    }
    public class LogroRepository : ILogroRepository
    {

        private readonly BLDbContext _db;

        public LogroRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<Logro> CreateLogro(string Descripcion, DateTime Fecha, int Puntos)
        {
            Logro newLogro = new Logro
            {

                Descripcion = Descripcion,
                Fecha = Fecha,
                Puntos = Puntos
            };
            await _db.Logro.AddAsync(newLogro);
            _db.SaveChanges();
            return newLogro;
        }

        /*public async Task<Logro> DeleteLogro(Logro logro)
        {
            await _db.Logro.AddAsync(logro);
            _db.SaveChanges();
            return logro;
        }*/
        public async Task<Logro> DeleteLogro(Logro logro)
        {
            _db.Logro.Attach(logro); //Llamamos la actualizacion
            _db.Entry(logro).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return logro;
        }

        public async Task<List<Logro>> GetAll()
        {
            return await _db.Logro.ToListAsync();
        }

        public async Task<Logro> GetLogro(int IdLogro)
        {
            return await _db.Logro.FirstOrDefaultAsync(a => a.IdLogro == IdLogro);
        }

        public async Task<Logro> UpdateLogro(Logro logro)
        {
            Logro ConsultUpdate = await _db.Logro.FindAsync(logro.IdLogro);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Descripcion = logro.Descripcion;
                ConsultUpdate.Fecha = logro.Fecha;
                ConsultUpdate.Puntos = logro.Puntos;


                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}
