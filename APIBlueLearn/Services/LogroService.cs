using APIBlueLearn.Model;
using APIBlueLearn.Repositories;

namespace APIBlueLearn.Services
{

    public interface ILogroService
    {
        Task<List<Logro>> GetAll();
        Task<Logro> GetLogro(int IdLogro);
        Task<Logro> CreateLogro(string Descripcion, DateTime Fecha, int Puntos);
        Task<Logro> UpdateLogro(int IdLogro, string? Descripcion = null, DateTime? Fecha = null, int? Puntos = null);
        Task<Logro> DeleteLogro(int IdLogro);
    }
    public class LogroService : ILogroService
    {

        public readonly ILogroRepository _logroRepository;

        public LogroService(ILogroRepository logroRepository)
        {
            _logroRepository = logroRepository;
        }

        public async Task<Logro> CreateLogro(string Descripcion, DateTime Fecha, int Puntos)
        {
            return await _logroRepository.CreateLogro(Descripcion, Fecha, Puntos);
        }

        /*public async Task<Logro> DeleteLogro(int IdLogro)
        {
            Logro logro = await _logroRepository.GetLogro(IdLogro);
            return await _logroRepository.DeleteLogro(logro);
        }*/

        public async Task<Logro> DeleteLogro(int IdLogro)
        {
            Logro logroToDelete = await _logroRepository.GetLogro(IdLogro);
            if (logroToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdLogro} don´t exist. ");
            }
            logroToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _logroRepository.DeleteLogro(logroToDelete);
        }

        public async Task<List<Logro>> GetAll()
        {
            return await _logroRepository.GetAll();
        }

        public async Task<Logro> GetLogro(int IdLogro)
        {
            return await _logroRepository.GetLogro(IdLogro);
        }

        public async Task<Logro> UpdateLogro(int IdLogro, string? Descripcion = null, DateTime? Fecha = null, int? Puntos = null)
        {
            Logro newLogro = await _logroRepository.GetLogro(IdLogro);
            if (newLogro != null)
            {
                if (Descripcion != null)
                {
                    newLogro.Descripcion = Descripcion;
                }
                if (Fecha != null)
                {
                    newLogro.Fecha = (DateTime)Fecha;
                }
                if (Puntos != null)
                {
                    newLogro.Puntos = (int)Puntos;
                }
                return await _logroRepository.UpdateLogro(newLogro);
            }
            throw new InvalidOperationException("Registro no encontrado.");
        }
    }

}
