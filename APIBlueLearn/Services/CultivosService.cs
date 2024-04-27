using APIBlueLearn.Model;
using APIBlueLearn.Repositories;

namespace APIBlueLearn.Services
{

    public interface ICultivosService
    {
        Task<List<Cultivos>> GetAll();
        Task<Cultivos> GetCultivos(int IdCultivo);
        Task<Cultivos> CreateCultivos(DateTime FechaPlantacion, int IdEstadoCultivo, int IdCampo);
        Task<Cultivos> UpdateCultivos(int IdCultivo, DateTime? FechaPlantacion = null, int? IdEstadoCultivo = null, int? IdCampo = null);
        Task<Cultivos> DeleteCultivos(int IdCultivo);
    }
    public class CultivosService : ICultivosService
    {

        public readonly ICultivosRepository _cultivosRepository;

        public CultivosService(ICultivosRepository cultivosRepository)
        {
            _cultivosRepository = cultivosRepository;
        }

        public async Task<Cultivos> CreateCultivos(DateTime FechaPlantacion, int IdEstadoCultivo, int IdCampo)
        {
            return await _cultivosRepository.CreateCultivos(FechaPlantacion, IdEstadoCultivo, IdCampo);
        }

        /*public async Task<Cultivos> DeleteCultivos(int IdCultivo)
        {
            Cultivos cultivos = await _cultivosRepository.GetCultivos(IdCultivo);
            return await _cultivosRepository.DeleteCultvios(cultivos);
        }*/

        public async Task<Cultivos> DeleteCultivos(int IdCultivo)
        {
            Cultivos cultivosToDelete = await _cultivosRepository.GetCultivos(IdCultivo);
            if (cultivosToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdCultivo} don´t exist. ");
            }
            cultivosToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _cultivosRepository.DeleteCultivos(cultivosToDelete);
        }

        public async Task<List<Cultivos>> GetAll()
        {
            return await _cultivosRepository.GetAll();
        }

        public async Task<Cultivos> GetCultivos(int IdCultivo)
        {
            return await _cultivosRepository.GetCultivos(IdCultivo);
        }

        public async Task<Cultivos> UpdateCultivos(int IdCultivo, DateTime? FechaPlantacion = null, int? IdEstadoCultivo = null, int? IdCampo = null)
        {
            Cultivos newCultivos = await _cultivosRepository.GetCultivos(IdCultivo);
            if (newCultivos != null)
            {
                if (FechaPlantacion != null)
                {
                    newCultivos.FechaPlantacion = (DateTime)FechaPlantacion;
                }
                if (IdEstadoCultivo != null)
                {
                    newCultivos.IdEstadoCultivo = (int)IdEstadoCultivo;
                }
                if (IdCampo != null)
                {
                    newCultivos.IdCultivo = (int)IdCampo;
                }
                return await _cultivosRepository.UpdateCultivos(newCultivos);
            }
            throw new InvalidOperationException("Registro no encontrado");
        }
    }
}
