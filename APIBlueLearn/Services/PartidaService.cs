using APIBlueLearn.Model;
using APIBlueLearn.Repositories;

namespace APIBlueLearn.Services
{

    public interface IPartidaService
    {
        Task<List<Partida>> GetAll();
        Task<Partida> GetPartida(int IdPartida);
        Task<Partida> CreatePartida(string NombrePartida, int IdJugador, int IdLogro, int PuntajePartida);
        Task<Partida> UpdatePartida(int IdPartida, string? NombrePartida = null, int? IdJugador = null, int? IdLogro = null, int? PuntajePartida = null);
        Task<Partida> DeletePartida(int IdPartida);
    }
    public class PartidaService : IPartidaService
    {
        public readonly IPartidaRepository _partidaRepository;

        public PartidaService(IPartidaRepository partidaRepository)
        {
            _partidaRepository = partidaRepository;
        }

        public async Task<Partida> CreatePartida(string NombrePartida, int IdJugador, int IdLogro, int PuntajePartida)
        {
            return await _partidaRepository.CreatePartida(NombrePartida, IdJugador, IdLogro, PuntajePartida);
        }

        /*public async Task<Partida> DeletePartida(int IdPartida)
        {
            Partida partida = await _partidaRepository.GetPartida(IdPartida);
            return await _partidaRepository.DeletePartida(partida);
        }*/

        public async Task<Partida> DeletePartida(int IdPartida)
        {
            Partida partidaToDelete = await _partidaRepository.GetPartida(IdPartida);
            if (partidaToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdPartida} don´t exist. ");
            }
            partidaToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _partidaRepository.DeletePartida(partidaToDelete);
        }

        public async Task<List<Partida>> GetAll()
        {
            return await _partidaRepository.GetAll();
        }

        public async Task<Partida> GetPartida(int IdPartida)
        {
            return await _partidaRepository.GetPartida(IdPartida);
        }

        public async Task<Partida> UpdatePartida(int IdPartida, string? NombrePartida = null, int? IdJugador = null, int? IdLogro = null, int? PuntajePartida = null)
        {
            Partida newPartida = await _partidaRepository.GetPartida(IdPartida);
            if (newPartida != null)
            {
                if (NombrePartida != null)
                {
                    newPartida.NombrePartida = NombrePartida;
                }
                if (IdJugador != null)
                {
                    newPartida.IdJugador = (int)IdJugador;
                }

                if (IdLogro != null)
                {
                    newPartida.IdLogro = (int)IdLogro;
                }
                if (PuntajePartida != null)
                {
                    newPartida.PuntajePartida = (int)PuntajePartida;
                }
                return await _partidaRepository.UpdatePartida(newPartida);
            }
            throw new InvalidOperationException("Registro no encontrado.");
        }
    }
}
