using Microsoft.EntityFrameworkCore;
using APIBlueLearn.Context;
using APIBlueLearn.Model;


namespace APIBlueLearn.Repositories
{

    public interface ICosechasRepository
    {
        Task<List<Cosechas>> GetAll();
        Task<Cosechas> GetCosechas(int IdCosechas);
        Task<Cosechas> CreateCosechas(DateTime FechaCosecha, int CantidadRecogida, int IdCultivo, int IdTemporada);
        Task<Cosechas> UpdateCosechas(Cosechas cosechas);
        Task<Cosechas> DeleteCosechas(Cosechas cosechas);
    }
    public class CosechasRepository : ICosechasRepository
    {

        private readonly BLDbContext _db;

        public CosechasRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<Cosechas> CreateCosechas(DateTime FechaCosecha, int CantidadRecogida, int IdCultivo, int IdTemporada)
        {
            Cosechas newCosechas = new Cosechas
            {
                FechaCosecha = FechaCosecha,
                CantidadRecogida = CantidadRecogida,
                IdCultivo = (int)IdCultivo,
                IdTemporada = (int)IdTemporada
            };

            await _db.Cosechas.AddAsync(newCosechas);
            _db.SaveChanges();
            return newCosechas;
        }

        /*public async Task<Cosechas> DeleteCosechas(Cosechas cosechas)
        {
            await _db.Cosechas.AddAsync(cosechas);
            _db.SaveChanges();
            return cosechas;
        }*/

        public async Task<Cosechas> DeleteCosechas(Cosechas cosechas)
        {
            _db.Cosechas.Attach(cosechas); //Llamamos la actualizacion
            _db.Entry(cosechas).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return cosechas;
        }

        public async Task<List<Cosechas>> GetAll()
        {
            return await _db.Cosechas.ToListAsync();
        }

        public async Task<Cosechas> GetCosechas(int IdCosechas)
        {
            return await _db.Cosechas.FirstOrDefaultAsync(o => o.IdCosechas == IdCosechas);
        }

        public async Task<Cosechas> UpdateCosechas(Cosechas cosechas)
        {
            Cosechas ConsultUpdate = await _db.Cosechas.FindAsync(cosechas.IdCosechas);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.FechaCosecha = cosechas.FechaCosecha;
                ConsultUpdate.CantidadRecogida = cosechas.CantidadRecogida;
                ConsultUpdate.IdCultivo = cosechas.IdCultivo;
                ConsultUpdate.IdTemporada = cosechas.IdTemporada;



                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}
