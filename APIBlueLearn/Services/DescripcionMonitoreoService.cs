using APIBlueLearn.Model;
using APIBlueLearn.Repositories;

namespace APIBlueLearn.Services
{

    public interface IDescripcionMonitoreoService
    {
        Task<List<DescripcionMonitoreo>> GetAll();
        Task<DescripcionMonitoreo> GetDMonitoreo(int IdDescripcionMonitoreo);
        Task<DescripcionMonitoreo> CreateDMonitoreo(string Variable, string UnidadMedida);
        Task<DescripcionMonitoreo> UpdateDMonitoreo(int IdDescripcionMonitoreo, string? Variable = null, string? UnidadMedida = null);
        Task<DescripcionMonitoreo> DeleteDMonitoreo(int IdDescripcionMonitoreo);
    }
    public class DescripcionMonitoreoService : IDescripcionMonitoreoService
    {
        public readonly IDescripcionMonitoreoRepository _descripcionMonitoreoRepository;

        public DescripcionMonitoreoService(IDescripcionMonitoreoRepository descripcionMonitoreoRepository)
        {
            _descripcionMonitoreoRepository = descripcionMonitoreoRepository;
        }

        public async Task<DescripcionMonitoreo> CreateDMonitoreo(string Variable, string UnidadMedida)
        {
            return await _descripcionMonitoreoRepository.CreateDMonitoreo(Variable, UnidadMedida);
        }

        /*public async Task<DescripcionMonitoreo> DeleteDMonitoreo(int IdDescripcionMonitoreo)
        {
            DescripcionMonitoreo descripcionMonitoreo = await _descripcionMonitoreoRepository.GetDMonitoreo(IdDescripcionMonitoreo);
            return await _descripcionMonitoreoRepository.DeleteDMonitoreo(descripcionMonitoreo);
        }*/
        public async Task<DescripcionMonitoreo> DeleteDMonitoreo(int IdDescripcionMonitoreo)
        {
            DescripcionMonitoreo descripcionMonitoreoToDelete = await _descripcionMonitoreoRepository.GetDMonitoreo(IdDescripcionMonitoreo);
            if (descripcionMonitoreoToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdDescripcionMonitoreo} don´t exist. ");
            }
            descripcionMonitoreoToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _descripcionMonitoreoRepository.DeleteDMonitoreo(descripcionMonitoreoToDelete);
        }

        public async Task<List<DescripcionMonitoreo>> GetAll()
        {
            return await _descripcionMonitoreoRepository.GetAll();
        }

        public async Task<DescripcionMonitoreo> GetDMonitoreo(int IdDescripcionMonitoreo)
        {
            return await _descripcionMonitoreoRepository.GetDMonitoreo(IdDescripcionMonitoreo);
        }

        public async Task<DescripcionMonitoreo> UpdateDMonitoreo(int IdDescripcionMonitoreo, string? Variable = null, string? UnidadMedida = null)
        {
            DescripcionMonitoreo newDescripcionMonitoreo = await _descripcionMonitoreoRepository.GetDMonitoreo(IdDescripcionMonitoreo);
            if (newDescripcionMonitoreo != null)
            {
                if (Variable != null)
                {
                    newDescripcionMonitoreo.Variable = Variable;
                }
                if (UnidadMedida != null)
                {
                    newDescripcionMonitoreo.UnidadMedida = UnidadMedida;
                }
                return await _descripcionMonitoreoRepository.UpdateDMonitoreo(newDescripcionMonitoreo);
            }
            throw new InvalidOperationException("Registro no encontrado");
        }
    }
}
