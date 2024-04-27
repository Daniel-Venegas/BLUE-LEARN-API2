using Microsoft.EntityFrameworkCore;
using APIBlueLearn.Context;
using APIBlueLearn.Model;


namespace APIBlueLearn.Repositories
{

    public interface IOperacionesCultivoRepository
    {
        Task<List<OperacionesCultivo>> GetAll();
        Task<OperacionesCultivo> GetOperacionesCultivo(int IdOperacion);
        Task<OperacionesCultivo> CreateOperacionesCultivo(int IdEstadoOperacion, DateTime FechaOperacion, string Descripcion, int IdCultivo, int IdAgricultor);
        Task<OperacionesCultivo> UpdateOperacionesCultivo(OperacionesCultivo operacionesCultivo);
        Task<OperacionesCultivo> DeleteOperacionesCultivo(OperacionesCultivo operacionesCultivo);
    }
    public class OperacionesCultivoRepository : IOperacionesCultivoRepository
    {

        private readonly BLDbContext _db;

        public OperacionesCultivoRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<OperacionesCultivo> CreateOperacionesCultivo(int IdEstadoOperacion, DateTime FechaOperacion, string Descripcion, int IdCultivo, int IdAgricultor)
        {
            OperacionesCultivo newOperacionesCultivo = new OperacionesCultivo
            {
                IdEstadoOperacion = IdEstadoOperacion,
                FechaOperacion = FechaOperacion,
                Descripcion = Descripcion,
                IdCultivo = IdCultivo,
                IdAgricultor = IdAgricultor
            };
            await _db.OpeCultivos.AddAsync(newOperacionesCultivo);
            _db.SaveChanges();
            return newOperacionesCultivo;
        }

        /*public async Task<OperacionesCultivo> DeleteOperacionesCultivo(OperacionesCultivo operacionesCultivo)
        {
            await _db.OpeCultivos.AddAsync(operacionesCultivo);
            _db.SaveChanges();
            return operacionesCultivo;
        }*/
        public async Task<OperacionesCultivo> DeleteOperacionesCultivo(OperacionesCultivo operacionesCultivo)
        {
            _db.OpeCultivos.Attach(operacionesCultivo); //Llamamos la actualizacion
            _db.Entry(operacionesCultivo).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return operacionesCultivo;
        }

        public async Task<List<OperacionesCultivo>> GetAll()
        {
            return await _db.OpeCultivos.ToListAsync();
        }

        public async Task<OperacionesCultivo> GetOperacionesCultivo(int IdOperacion)
        {
            return await _db.OpeCultivos.FirstOrDefaultAsync(o => o.IdOperacion == IdOperacion);
        }

        public async Task<OperacionesCultivo> UpdateOperacionesCultivo(OperacionesCultivo operacionesCultivo)
        {
            OperacionesCultivo ConsultUpdate = await _db.OpeCultivos.FindAsync(operacionesCultivo.IdOperacion);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.IdEstadoOperacion = operacionesCultivo.IdEstadoOperacion;
                ConsultUpdate.FechaOperacion = operacionesCultivo.FechaOperacion;
                ConsultUpdate.Descripcion = operacionesCultivo.Descripcion;
                ConsultUpdate.IdCultivo = operacionesCultivo.IdCultivo;
                ConsultUpdate.IdAgricultor = operacionesCultivo.IdAgricultor;

                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}
