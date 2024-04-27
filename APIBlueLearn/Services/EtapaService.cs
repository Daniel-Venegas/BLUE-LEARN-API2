using APIBlueLearn.Model;
using APIBlueLearn.Repositories;

namespace APIBlueLearn.Services
{

    public interface IEtapaService
    {
        Task<List<Etapa>> GetAll();
        Task<Etapa> GetEtapa(int IdEtapa);
        Task<Etapa> CreateEtapa(string Descripcion);
        Task<Etapa> UpdateEtapa(int IdEtapa, string? Descripcion = null);
        Task<Etapa> DeleteEtapa(int IdEtapa);
    }
    public class EtapaService : IEtapaService
    {

        public readonly IEtapaRepository _etapaRepository;

        public EtapaService(IEtapaRepository etapaRepository)
        {
            _etapaRepository = etapaRepository;
        }

        public async Task<Etapa> CreateEtapa(string Descripcion)
        {
            return await _etapaRepository.CreateEtapa(Descripcion);
        }

        /*public async Task<Etapa> DeleteEtapa(int IdEtapa)
        {
            Etapa etapa = await _etapaRepository.GetEtapa(IdEtapa);
            return await _etapaRepository.DeleteEtapa(etapa);
        }*/

        public async Task<Etapa> DeleteEtapa(int IdEtapa)
        {
            Etapa estadoToDelete = await _etapaRepository.GetEtapa(IdEtapa);
            if (estadoToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdEtapa} don´t exist. ");
            }
            estadoToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _etapaRepository.DeleteEtapa(estadoToDelete);
        }

        public async Task<List<Etapa>> GetAll()
        {
            return await _etapaRepository.GetAll();
        }

        public async Task<Etapa> GetEtapa(int IdEtapa)
        {
            return await _etapaRepository.GetEtapa(IdEtapa);
        }

        public async Task<Etapa> UpdateEtapa(int IdEtapa, string? Descripcion = null)
        {
            Etapa newEtapa = await _etapaRepository.GetEtapa(IdEtapa);
            if (newEtapa != null)
            {
                if (Descripcion != null)
                {
                    newEtapa.Descripcion = Descripcion;
                }
                return await _etapaRepository.UpdateEtapa(newEtapa);
            }
            throw new InvalidOperationException("Registro no encontrado");
        }
    }
}
