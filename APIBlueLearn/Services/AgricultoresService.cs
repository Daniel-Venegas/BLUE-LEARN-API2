using APIBlueLearn.Model;
using APIBlueLearn.Repositories;

namespace APIBlueLearn.Services
{

    public interface IAgricultoresService
    {
        Task<List<Agricultores>> GetAll();
        Task<Agricultores> GetAgricultor(int IdAgricultor);
        Task<Agricultores> CreateAgricultor(int IdJugador, string Nombres, string Apellidos, string Direccion, string Contacto, Jugador jugador);
        Task<Agricultores> UpdateAgricultor(int IdAgricultor, int? IdJugador = null, string? Nombres = null, string? Apellidos = null, string? Direccion = null, string? Contacto = null);
        Task<Agricultores> DeleteAgricultor(int IdAgricultor);
    }
    public class AgricultoresService : IAgricultoresService
    {

        public readonly IAgricultoresRepository _agricultoresRepository;

        public AgricultoresService(IAgricultoresRepository agricultoresRepository)
        {
            _agricultoresRepository = agricultoresRepository;
        }
        public async Task<Agricultores> CreateAgricultor(int IdJugador, string Nombres, string Apellidos, string Direccion, string Contacto, Jugador jugador)
        {
            return await _agricultoresRepository.CreateAgricultor(IdJugador, Nombres, Apellidos, Direccion, Contacto, jugador);
        }

        /*public async Task<Agricultores> DeleteAgricultor(int IdAgricultor)
        {
            Agricultores agricultores = await _agricultoresRepository.GetAgricultor(IdAgricultor);
            return await _agricultoresRepository.DeleteAgricultor(agricultores);
        }*/

        public async Task<Agricultores> DeleteAgricultor(int IdAgricultor)
        {
            Agricultores agricultoresToDelete = await _agricultoresRepository.GetAgricultor(IdAgricultor);
            if (agricultoresToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdAgricultor} don´t exist. ");
            }
            agricultoresToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _agricultoresRepository.DeleteAgricultor(agricultoresToDelete);
        }

            public async Task<Agricultores> GetAgricultor(int IdAgricultor)
        {
            return await _agricultoresRepository.GetAgricultor(IdAgricultor);
        }

        public async Task<List<Agricultores>> GetAll()
        {
            return await _agricultoresRepository.GetAll();
        }

        public async Task<Agricultores> UpdateAgricultor(int IdAgricultor, int? IdJugador = null, string? Nombres = null, string? Apellidos = null, string? Direccion = null, string? Contacto = null)
        {
            Agricultores newAgricultores = await _agricultoresRepository.GetAgricultor(IdAgricultor);
            if (newAgricultores != null)
            {

                if (IdJugador != null)
                {
                    newAgricultores.IdJugador = (int)IdJugador;
                }
                if (Nombres != null)
                {
                    newAgricultores.Nombres = Nombres;
                }
                if (Apellidos != null)
                {
                    newAgricultores.Apellidos = Apellidos;
                }
                if (Direccion != null)
                {
                    newAgricultores.Direccion = Direccion;
                }
                if (Contacto != null)
                {
                    newAgricultores.Contacto = Contacto;
                }
                return await _agricultoresRepository.UpdateAgricultor(newAgricultores);
            }
            throw new InvalidOperationException("Registro no encontrado.");
        }
    }
}
