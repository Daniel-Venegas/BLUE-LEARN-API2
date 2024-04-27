using APIBlueLearn.Model;
using APIBlueLearn.Repositories;

namespace APIBlueLearn.Services
{

    public interface IJugadorService
    {
        Task<List<Jugador>> GetAll();
        Task<Jugador> GetJugador(int IdJugador);
        Task<Jugador> CreateJugador(int Puntaje, int Nivel);
        Task<Jugador> UpdateJugador(int IdJugador, int? Puntaje = null, int? Nivel = null);
        Task<Jugador> DeleteJugador(int IdJugador);
    }
    public class JugadorService : IJugadorService
    {

        public readonly IJugadorRepository _jugadorRepository;

        public JugadorService(IJugadorRepository jugadorRepository)
        {
            _jugadorRepository = jugadorRepository;
        }

        public async Task<Jugador> CreateJugador(int Puntaje, int Nivel)
        {
            return await _jugadorRepository.CreateJugador(Puntaje, Nivel);
        }

        /*public async Task<Jugador> DeleteJugador(int IdJugador)
        {
            Jugador jugador = await _jugadorRepository.GetJugador(IdJugador);
            return await _jugadorRepository.DeleteJugador(jugador);
        }*/

        public async Task<Jugador> DeleteJugador(int IdJugador)
        {
            Jugador jugadorToDelete = await _jugadorRepository.GetJugador(IdJugador);
            if (jugadorToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdJugador} don´t exist. ");
            }
            jugadorToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _jugadorRepository.DeleteJugador(jugadorToDelete);
        }

        public async Task<List<Jugador>> GetAll()
        {
            return await _jugadorRepository.GetAll();
        }

        public async Task<Jugador> GetJugador(int IdJugador)
        {
            return await _jugadorRepository.GetJugador(IdJugador);
        }

        public async Task<Jugador> UpdateJugador(int IdJugador, int? Puntaje = null, int? Nivel = null)
        {
            Jugador newJugador = await _jugadorRepository.GetJugador(IdJugador);
            if (newJugador != null)
            {
                if (Puntaje != null)
                {
                    newJugador.Puntaje = (int)Puntaje;
                }
                if (Nivel != null)
                {
                    newJugador.Nivel = (int)Nivel;
                }
                return await _jugadorRepository.UpdateJugador(newJugador);
            }
            throw new InvalidOperationException("Registro no encontrado");
        }
    }
}
