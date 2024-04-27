using APIBlueLearn.Model;
using APIBlueLearn.Repositories;

namespace APIBlueLearn.Services
{

    public interface IEtapaAprendizajeService
    {
        Task<List<EtapaAprendizaje>> GetAll();
        Task<EtapaAprendizaje> GetEtapaAprendizaje(int IdEstado);
        Task<EtapaAprendizaje> CreateEtapaAprendizaje(int IdAgricultor, int IdEtapa, DateTime FechaInit, DateTime FechaFin);
        Task<EtapaAprendizaje> UpdateEtapaAprendizaje(int IdEstado, int? IdAgricultor = null, int? IdEtapa = null, DateTime? FechaInit = null, DateTime? FechaFin = null);
        Task<EtapaAprendizaje> DeleteEtapaAprendizaje(int IdEstado);

    }
    public class EtapaAprendizajeService : IEtapaAprendizajeService
    {
        public readonly IEtapaAprendizajeRepository _etapaAprendizajeRepository;

        public EtapaAprendizajeService(IEtapaAprendizajeRepository etapaAprendizajeRepository)
        {
            _etapaAprendizajeRepository = etapaAprendizajeRepository;
        }

        public async Task<EtapaAprendizaje> CreateEtapaAprendizaje(int IdAgricultor, int IdEtapa, DateTime FechaInit, DateTime FechaFin)
        {
            return await _etapaAprendizajeRepository.CreateEtapaAprendizaje(IdAgricultor, IdEtapa, FechaInit, FechaFin);
        }

        /*public async Task<EtapaAprendizaje> DeleteEtapaAprendizaje(int IdEstado)
        {
            EtapaAprendizaje etapaAprendizaje = await _etapaAprendizajeRepository.GetEtapaAprendizaje(IdEstado);
            return await _etapaAprendizajeRepository.DeleteEtapaAprendizaje(etapaAprendizaje);
        }*/

        public async Task<EtapaAprendizaje> DeleteEtapaAprendizaje(int IdEstado)
        {
            EtapaAprendizaje estadoAprendizajeToDelete = await _etapaAprendizajeRepository.GetEtapaAprendizaje(IdEstado);
            if (estadoAprendizajeToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdEstado} don´t exist. ");
            }
            estadoAprendizajeToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _etapaAprendizajeRepository.DeleteEtapaAprendizaje(estadoAprendizajeToDelete);
        }

        public async Task<List<EtapaAprendizaje>> GetAll()
        {
            return await _etapaAprendizajeRepository.GetAll();
        }

        public async Task<EtapaAprendizaje> GetEtapaAprendizaje(int IdEstado)
        {
            return await _etapaAprendizajeRepository.GetEtapaAprendizaje(IdEstado);
        }

        public async Task<EtapaAprendizaje> UpdateEtapaAprendizaje(int IdEstado, int? IdAgricultor = null, int? IdEtapa = null, DateTime? FechaInit = null, DateTime? FechaFin = null)
        {
            EtapaAprendizaje newEtapaAprendizaje = await _etapaAprendizajeRepository.GetEtapaAprendizaje(IdEstado);
            if (newEtapaAprendizaje != null)
            {
                if (IdAgricultor != null)
                {
                    newEtapaAprendizaje.IdAgricultor = (int)IdAgricultor;
                }
                if (IdEtapa != null)
                {
                    newEtapaAprendizaje.IdEtapa = (int)IdEtapa;
                }
                if (FechaInit != null)
                {
                    newEtapaAprendizaje.FechaInit = (DateTime)FechaInit;
                }
                if (FechaFin != null)
                {
                    newEtapaAprendizaje.FechaFin = (DateTime)FechaFin;
                }
                return await _etapaAprendizajeRepository.UpdateEtapaAprendizaje(newEtapaAprendizaje);
            }
            throw new InvalidOperationException("Registro no encontrado");
        }
    }
}
