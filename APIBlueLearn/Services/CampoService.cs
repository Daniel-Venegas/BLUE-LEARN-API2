using APIBlueLearn.Model;
using APIBlueLearn.Repositories;


namespace APIBlueLearn.Services
{

    public interface ICampoService
    {
        Task<List<Campos>> GetAll();
        Task<Campos> GetCampos(int IdCampo);
        Task<Campos> CreateCampos(string NombreCampo, string Ubicacion, int Tamano);
        Task<Campos> UpdateCampos(int IdCampo, string? NombreCampo = null, string? Ubicacion = null, int? Tamano = null);
        Task<Campos> DeleteCampos(int IdAgricultor);
    }
    public class CampoService : ICampoService
    {
        public readonly ICamposRepository _campoRepository;

        public CampoService(ICamposRepository campoRepository)
        {
            _campoRepository = campoRepository;
        }

        public async Task<Campos> CreateCampos(string NombreCampo, string Ubicacion, int Tamano)
        {
            return await _campoRepository.CreateCampos(NombreCampo, Ubicacion, Tamano);
        }

        /*public async Task<Campos> DeleteCampos(int IdAgricultor)
        {
            Campos campos = await _campoRepository.GetCampos(IdAgricultor);
            return await _campoRepository.DeleteCampos(campos);
        }*/
        public async Task<Campos> DeleteCampos(int IdAgricultor)
        {
            Campos camposToDelete = await _campoRepository.GetCampos(IdAgricultor);
            if (camposToDelete == null)
            {
                throw new Exception($"This patient with the Id {IdAgricultor} don´t exist. ");
            }
            camposToDelete.Eliminado = true;
            /*agricultoresToDelete.CreatedDate = DateTime.Now;*/

            return await _campoRepository.DeleteCampos(camposToDelete);
        }

        public async Task<Campos> GetCampos(int IdCampo)
        {
            return await _campoRepository.GetCampos(IdCampo);
        }

        public async Task<List<Campos>> GetAll()
        {
            return await _campoRepository.GetAll();
        }

        public async Task<Campos> UpdateCampos(int IdCampo, string? NombreCampo = null, string? Ubicacion = null, int? Tamano = null)
        {
            Campos newCampos = await _campoRepository.GetCampos(IdCampo);
            if (newCampos != null)
            {
                if (NombreCampo != null)
                {
                    newCampos.NombreCampo = NombreCampo;
                }
                if (Ubicacion != null)
                {
                    newCampos.Ubicacion = Ubicacion;
                }
                if (Tamano != null)
                {
                    newCampos.Tamano = (int)Tamano;
                }
                return await _campoRepository.UpdateCampos(newCampos);
            }
            throw new InvalidOperationException("Registro no encontrado.");
        }
    }
}
