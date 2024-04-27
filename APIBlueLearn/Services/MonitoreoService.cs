using APIBlueLearn.Model;
using APIBlueLearn.Repositories;

namespace APIBlueLearn.Services
{

    public interface IMonitoreoService
    {
        Task<List<Monitoreo>> GetAll();
        Task<Monitoreo> GetMonitoreo(int IdMonitoreo);
        Task<Monitoreo> CreateMonitoreo(DateTime FechaMonitoreo, int Valor, int IdDescripcionMonitoreo, int IdCultivo);
        Task<Monitoreo> UpdateMonitoreo(int IdMonitoreo, DateTime? FechaMonitoreo = null, int? Valor = null, int? IdDescripcionMonitoreo = null, int? IdCultivo = null);
        Task<Monitoreo> DeleteMonitoreo(int IdMonitoreo);

    }
    public class MonitoreoService : IMonitoreoService
    {

        public readonly IMonitoreoRepository _monitoreoRepository;

        public MonitoreoService(IMonitoreoRepository monitoreoRepository)
        {
            _monitoreoRepository = monitoreoRepository;
        }

        public async Task<Monitoreo> CreateMonitoreo(DateTime FechaMonitoreo, int Valor, int IdDescripcionMonitoreo, int IdCultivo)
        {
            return await _monitoreoRepository.CreateMonitoreo(FechaMonitoreo, Valor, IdDescripcionMonitoreo, IdCultivo);
        }

        /*public async Task<Monitoreo> DeleteMonitoreo(int IdMonitoreo)
        {
            Monitoreo monitoreo = await _monitoreoRepository.GetMonitoreo(IdMonitoreo);
            return await _monitoreoRepository.DeleteMonitoreo(monitoreo);
        }*/

        public async Task<Monitoreo> DeleteMonitoreo(int IdMonitoreo)
        {
            Monitoreo monitoreoToDelete = await _monitoreoRepository.GetMonitoreo(IdMonitoreo);
            if (monitoreoToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdMonitoreo} don´t exist. ");
            }
            monitoreoToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _monitoreoRepository.DeleteMonitoreo(monitoreoToDelete);
        }

        public async Task<List<Monitoreo>> GetAll()
        {
            return await _monitoreoRepository.GetAll();
        }

        public async Task<Monitoreo> GetMonitoreo(int IdMonitoreo)
        {
            return await _monitoreoRepository.GetMonitoreo(IdMonitoreo);
        }

        public async Task<Monitoreo> UpdateMonitoreo(int IdMonitoreo, DateTime? FechaMonitoreo = null, int? Valor = null, int? IdDescripcionMonitoreo = null, int? IdCultivo = null)
        {
            Monitoreo newMonitoreo = await _monitoreoRepository.GetMonitoreo(IdMonitoreo);
            if (newMonitoreo != null)
            {
                if (FechaMonitoreo != null)
                {
                    newMonitoreo.FechaMonitoreo = (DateTime)FechaMonitoreo;
                }
                if (Valor != null)
                {
                    newMonitoreo.Valor = (int)Valor;
                }
                if (IdDescripcionMonitoreo != null)
                {
                    newMonitoreo.IdDescripcionMonitoreo = (int)IdDescripcionMonitoreo;
                }
                if (IdCultivo != null)
                {
                    newMonitoreo.IdCultivo = (int)IdCultivo;
                }
                return await _monitoreoRepository.UpdateMonitoreo(newMonitoreo);

            }
            throw new InvalidOperationException("Registro no encontrado.");
        }
    }
}
