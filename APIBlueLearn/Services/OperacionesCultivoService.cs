using APIBlueLearn.Model;
using APIBlueLearn.Repositories;

namespace APIBlueLearn.Services
{

    public interface IOperacionesCultivoService
    {
        Task<List<OperacionesCultivo>> GetAll();
        Task<OperacionesCultivo> GetOperacionesCultivo(int IdOperacion);
        Task<OperacionesCultivo> CreateOperacionesCultivo(int IdEstadoOperacion, DateTime FechaOperacion, string Descripcion, int IdCultivo, int IdAgricultor);
        Task<OperacionesCultivo> UpdateOperacionesCultivo(int IdOperacion, int? IdEstadoOperacion = null, DateTime? FechaOperacion = null, string? Descripcion = null, int? IdCultivo = null, int? IdAgricultor = null);
        Task<OperacionesCultivo> DeleteOperacionesCultivo(int IdOperacion);

    }
    public class OperacionesCultivoService : IOperacionesCultivoService
    {

        public readonly IOperacionesCultivoRepository _operacionesCultivoRepository;

        public OperacionesCultivoService(IOperacionesCultivoRepository operacionesCultivoRepository)
        {
            _operacionesCultivoRepository = operacionesCultivoRepository;
        }

        public async Task<OperacionesCultivo> CreateOperacionesCultivo(int IdEstadoOperacion, DateTime FechaOperacion, string Descripcion, int IdCultivo, int IdAgricultor)
        {
            return await _operacionesCultivoRepository.CreateOperacionesCultivo(IdEstadoOperacion, FechaOperacion, Descripcion, IdCultivo, IdAgricultor);
        }

        /*public async Task<OperacionesCultivo> DeleteOperacionesCultivo(int IdOperacion)
        {
            OperacionesCultivo operacionesCultivo = await _operacionesCultivoRepository.GetOperacionesCultivo(IdOperacion);
            return await _operacionesCultivoRepository.UpdateOperacionesCultivo(operacionesCultivo);
        }*/
        public async Task<OperacionesCultivo> DeleteOperacionesCultivo(int IdOperacion)
        {
            OperacionesCultivo operacionesCultivoToDelete = await _operacionesCultivoRepository.GetOperacionesCultivo(IdOperacion);
            if (operacionesCultivoToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdOperacion} don´t exist. ");
            }
            operacionesCultivoToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _operacionesCultivoRepository.DeleteOperacionesCultivo(operacionesCultivoToDelete);
        }

        public async Task<List<OperacionesCultivo>> GetAll()
        {
            return await _operacionesCultivoRepository.GetAll();
        }

        public async Task<OperacionesCultivo> GetOperacionesCultivo(int IdOperacion)
        {
            return await _operacionesCultivoRepository.GetOperacionesCultivo(IdOperacion);
        }

        public async Task<OperacionesCultivo> UpdateOperacionesCultivo(int IdOperacion, int? IdEstadoOperacion = null, DateTime? FechaOperacion = null, string? Descripcion = null, int? IdCultivo = null, int? IdAgricultor = null)
        {
            OperacionesCultivo newOperacionesCultivo = await _operacionesCultivoRepository.GetOperacionesCultivo(IdOperacion);
            if (newOperacionesCultivo != null)
            {
                if (IdEstadoOperacion != null)
                {
                    newOperacionesCultivo.IdEstadoOperacion = (int)IdEstadoOperacion;
                }
                if (FechaOperacion != null)
                {
                    newOperacionesCultivo.FechaOperacion = (DateTime)FechaOperacion;
                }
                if (Descripcion != null)
                {
                    newOperacionesCultivo.Descripcion = Descripcion;
                }
                if (IdCultivo != null)
                {
                    newOperacionesCultivo.IdCultivo = (int)IdCultivo;
                }
                if (IdAgricultor != null)
                {
                    newOperacionesCultivo.IdAgricultor = (int)IdAgricultor;
                }
                return await _operacionesCultivoRepository.UpdateOperacionesCultivo(newOperacionesCultivo);
            }
            throw new InvalidOperationException("Registro no encontrado.");
        }
    }
}
