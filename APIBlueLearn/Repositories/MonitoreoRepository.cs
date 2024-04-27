using Microsoft.EntityFrameworkCore;
using APIBlueLearn.Context;
using APIBlueLearn.Model;




namespace APIBlueLearn.Repositories
{

    public interface IMonitoreoRepository
    {
        Task<List<Monitoreo>> GetAll();
        Task<Monitoreo> GetMonitoreo(int IdMonitoreo);
        Task<Monitoreo> CreateMonitoreo(DateTime FechaMonitoreo, int Valor, int IdDescripcionMonitoreo, int IdCultivo);
        Task<Monitoreo> UpdateMonitoreo(Monitoreo monitoreo);
        Task<Monitoreo> DeleteMonitoreo(Monitoreo monitoreo);

    }
    public class MonitoreoRepository : IMonitoreoRepository
    {

        private readonly BLDbContext _db;

        public MonitoreoRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<Monitoreo> CreateMonitoreo(DateTime FechaMonitoreo, int Valor, int IdDescripcionMonitoreo, int IdCultivo)
        {
            Monitoreo newMonitoreo = new Monitoreo
            {
                FechaMonitoreo = FechaMonitoreo,
                Valor = Valor,
                IdDescripcionMonitoreo = IdDescripcionMonitoreo,
                IdCultivo = IdCultivo
            };
            await _db.Monitoreo.AddAsync(newMonitoreo);
            _db.SaveChanges();
            return newMonitoreo;
        }

        /*public async Task<Monitoreo> DeleteMonitoreo(Monitoreo monitoreo)
        {
            await _db.Monitoreo.AddAsync(monitoreo);
            _db.SaveChanges();
            return monitoreo;
        }*/

        public async Task<Monitoreo> DeleteMonitoreo(Monitoreo monitoreo)
        {
            _db.Monitoreo.Attach(monitoreo); //Llamamos la actualizacion
            _db.Entry(monitoreo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return monitoreo;
        }

        public async Task<List<Monitoreo>> GetAll()
        {
            return await _db.Monitoreo.ToListAsync();
        }

        public async Task<Monitoreo> GetMonitoreo(int IdMonitoreo)
        {
            return await _db.Monitoreo.FirstOrDefaultAsync(m => m.IdMonitoreo == IdMonitoreo);
        }

        public async Task<Monitoreo> UpdateMonitoreo(Monitoreo monitoreo)
        {
            Monitoreo ConsultUpdate = await _db.Monitoreo.FindAsync(monitoreo.IdMonitoreo);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.FechaMonitoreo = monitoreo.FechaMonitoreo;
                ConsultUpdate.Valor = monitoreo.Valor;
                ConsultUpdate.IdDescripcionMonitoreo = monitoreo.IdDescripcionMonitoreo;
                ConsultUpdate.IdCultivo = monitoreo.IdCultivo;



                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}
