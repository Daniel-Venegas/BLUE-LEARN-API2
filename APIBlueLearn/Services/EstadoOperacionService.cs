using APIBlueLearn.Model;
using APIBlueLearn.Repositories;

namespace APIBlueLearn.Services
{
    public interface IEstadoOperacionService
    {
        Task<List<EstadoOperacion>> GetAll();
        Task<EstadoOperacion> GetEstadoOperacion(int IdEstadoOperacion);
        Task<EstadoOperacion> CreateEstadoOperacion(string Descripcion);
        Task<EstadoOperacion> UpdateEstadoOperacion(int IdEstadoOperacion, string? Descripcion=null);
        Task<EstadoOperacion> DeleteEstadoOperacion(int IdEstadoOperacion);
    }
    public class EstadoOperacionService : IEstadoOperacionService
    {
        public readonly IEstadoOperacionRepository _estadoOperacionRepository;

        public EstadoOperacionService(IEstadoOperacionRepository estadoOperacionRepository)
        {
            _estadoOperacionRepository = estadoOperacionRepository;
        }

        

        public async Task<EstadoOperacion> CreateEstadoOperacion(string Descripcion)
        {
            return await _estadoOperacionRepository.CreateEstadoOperacion(Descripcion);

        }

        /*public async Task<EstadoOperacion> DeleteEstadoOperacion(int IdEstadoOperacion)
        {
            EstadoOperacion estadoOperacion = await _estadoOperacionRepository.GetEstadoOperacion(IdEstadoOperacion);
            return await _estadoOperacionRepository.DeleteEstadoOperacion(estadoOperacion);
        }*/

        public async Task<EstadoOperacion> DeleteEstadoOperacion(int IdEstadoOperacion)
        {
            EstadoOperacion estadoOperacionToDelete = await _estadoOperacionRepository.GetEstadoOperacion(IdEstadoOperacion);
            if (estadoOperacionToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdEstadoOperacion} don´t exist. ");
            }
            estadoOperacionToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _estadoOperacionRepository.DeleteEstadoOperacion(estadoOperacionToDelete);
        }

        public async Task<List<EstadoOperacion>> GetAll()
        {
            return await _estadoOperacionRepository.GetAll();
        }

        public async Task<EstadoOperacion> GetEstadoOperacion(int IdEstadoOperacion)
        {
            return await _estadoOperacionRepository.GetEstadoOperacion(IdEstadoOperacion);
        }

        public async Task<EstadoOperacion> UpdateEstadoOperacion(int IdEstadoOperacion, string? Descripcion = null)
        {
            EstadoOperacion newEstadoOperacion = await _estadoOperacionRepository.GetEstadoOperacion(IdEstadoOperacion);
            if(newEstadoOperacion != null)
            {
                if(Descripcion != null)
                {
                    newEstadoOperacion.Descripcion = Descripcion;
                }
                return await _estadoOperacionRepository.UpdateEstadoOperacion(newEstadoOperacion);

            }
            throw new InvalidOperationException("Registro no encontrado");
        }
    }
}
