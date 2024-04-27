using APIBlueLearn.Model;
using APIBlueLearn.Repositories;


namespace APIBlueLearn.Services
{

    public interface ICosechasService
    {
        Task<List<Cosechas>> GetAll();
        Task<Cosechas> GetCosechas(int IdCosechas);
        Task<Cosechas> CreateCosechas(DateTime FechaCosecha, int CantidadRecogida, int IdCultivo, int IdTemporada);
        Task<Cosechas> UpdateCosechas(int IdCosechas, DateTime? FechaCosecha = null, int? CantidadRecogida = null, int? IdCultivo = null, int? IdTemporada = null);
        Task<Cosechas> DeleteCosechas(int IdCosechas);
    }
    public class CosechasService : ICosechasService
    {

        public readonly ICosechasRepository _cosechasRepository;

        public CosechasService(ICosechasRepository cosechasRepository)
        {
            _cosechasRepository = cosechasRepository;
        }

        public async Task<Cosechas> CreateCosechas(DateTime FechaCosecha, int CantidadRecogida, int IdCultivo, int IdTemporada)
        {
            return await _cosechasRepository.CreateCosechas(FechaCosecha, CantidadRecogida, IdCultivo, IdTemporada);
        }

        /*public async Task<Cosechas> DeleteCosechas(int IdCosechas)
        {
            Cosechas cosechas = await _cosechasRepository.GetCosechas(IdCosechas);
            return await _cosechasRepository.DeleteCosechas(cosechas);
        }*/
        public async Task<Cosechas> DeleteCosechas(int IdCosechas)
        {
            Cosechas cosechasToDelete = await _cosechasRepository.GetCosechas(IdCosechas);
            if (cosechasToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdCosechas} don´t exist. ");
            }
            cosechasToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _cosechasRepository.DeleteCosechas(cosechasToDelete);
        }

        public async Task<List<Cosechas>> GetAll()
        {
            return await _cosechasRepository.GetAll();
        }

        public async Task<Cosechas> GetCosechas(int IdCosechas)
        {
            return await _cosechasRepository.GetCosechas(IdCosechas);
        }

        public async Task<Cosechas> UpdateCosechas(int IdCosechas, DateTime? FechaCosecha = null, int? CantidadRecogida = null, int? IdCultivo = null, int? IdTemporada = null)
        {
            Cosechas newCosechas = await _cosechasRepository.GetCosechas(IdCosechas);
            if (newCosechas != null)
            {
                if (FechaCosecha != null)
                {
                    newCosechas.FechaCosecha = (DateTime)FechaCosecha;
                }
                if (CantidadRecogida != null)
                {
                    newCosechas.CantidadRecogida = (int)CantidadRecogida;
                }
                if (IdCultivo != null)
                {
                    newCosechas.IdCultivo = (int)IdCultivo;
                }
                if (IdTemporada != null)
                {
                    newCosechas.IdTemporada = (int)IdTemporada;
                }
                return await _cosechasRepository.UpdateCosechas(newCosechas);
            }
            throw new InvalidOperationException("Registro no encontrado.");
        }
    }
}

