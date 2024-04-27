using Microsoft.EntityFrameworkCore;
using APIBlueLearn.Context;
using APIBlueLearn.Model;


namespace APIBlueLearn.Repositories
{

    public interface IEtapaAprendizajeRepository
    {
        Task<List<EtapaAprendizaje>> GetAll();
        Task<EtapaAprendizaje> GetEtapaAprendizaje(int IdEstado);
        Task<EtapaAprendizaje> CreateEtapaAprendizaje(int IdAgricultor, int IdEtapa, DateTime FechaInit, DateTime FechaFin);
        Task<EtapaAprendizaje> UpdateEtapaAprendizaje(EtapaAprendizaje etapaAprendizaje);
        Task<EtapaAprendizaje> DeleteEtapaAprendizaje(EtapaAprendizaje etapaAprendizaje);
    }
    public class EtapaAprendizajeRepository : IEtapaAprendizajeRepository
    {

        private readonly BLDbContext _db;

        public EtapaAprendizajeRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<EtapaAprendizaje> CreateEtapaAprendizaje(int IdAgricultor, int IdEtapa, DateTime FechaInit, DateTime FechaFin)
        {
            EtapaAprendizaje newEtapaAprendizaje = new EtapaAprendizaje
            {
                IdAgricultor = IdAgricultor,
                IdEtapa = IdEtapa,
                FechaInit = FechaInit,
                FechaFin = FechaFin
            };
            await _db.EtapaAprendizaje.AddAsync(newEtapaAprendizaje);
            _db.SaveChanges();
            return newEtapaAprendizaje;

        }

        /*public async Task<EtapaAprendizaje> DeleteEtapaAprendizaje(EtapaAprendizaje etapaAprendizaje)
        {
            await _db.EtapaAprendizaje.AddAsync(etapaAprendizaje);
            _db.SaveChanges();
            return etapaAprendizaje;
        }*/
        public async Task<EtapaAprendizaje> DeleteEtapaAprendizaje(EtapaAprendizaje etapaAprendizaje)
        {
            _db.EtapaAprendizaje.Attach(etapaAprendizaje); //Llamamos la actualizacion
            _db.Entry(etapaAprendizaje).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return etapaAprendizaje;
        }

        public async Task<List<EtapaAprendizaje>> GetAll()
        {
            return await _db.EtapaAprendizaje.ToListAsync();
        }

        public async Task<EtapaAprendizaje> GetEtapaAprendizaje(int IdEstado)
        {
            return await _db.EtapaAprendizaje.FirstOrDefaultAsync(e => e.IdEstado == IdEstado);
        }

        public async Task<EtapaAprendizaje> UpdateEtapaAprendizaje(EtapaAprendizaje etapaAprendizaje)
        {
            EtapaAprendizaje ConsultUpdate = await _db.EtapaAprendizaje.FindAsync(etapaAprendizaje.IdEstado);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.IdAgricultor = etapaAprendizaje.IdAgricultor;
                ConsultUpdate.IdEtapa = etapaAprendizaje.IdEtapa;
                ConsultUpdate.FechaInit = etapaAprendizaje.FechaInit;
                ConsultUpdate.FechaFin = etapaAprendizaje.FechaFin;

                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}
