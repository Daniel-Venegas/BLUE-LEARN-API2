using Microsoft.EntityFrameworkCore;
using APIBlueLearn.Context;
using APIBlueLearn.Model;

namespace APIBlueLearn.Repositories
{

    public interface ICamposRepository
    {
        Task<List<Campos>> GetAll();
        Task<Campos> GetCampos(int IdCampo);
        Task<Campos> CreateCampos(string NombreCampo, string Ubicacion, int Tamano);
        Task<Campos> UpdateCampos(Campos campos);
        Task<Campos> DeleteCampos(Campos campos);
    }
    public class CampoRepository : ICamposRepository
    {
        private readonly BLDbContext _db;

        public CampoRepository(BLDbContext db)
        {
            _db = db;
        }

        public async Task<Campos> CreateCampos(string NombreCampo, string Ubicacion, int Tamano)
        {

            Campos newCampos = new Campos
            {
                NombreCampo = NombreCampo,
                Ubicacion = Ubicacion,
                Tamano = Tamano

            };
            await _db.Campos.AddAsync(newCampos);
            _db.SaveChanges();
            return newCampos;
        }

        /*public async Task<Campos> DeleteCampos(Campos campos)
        {
            await _db.Campos.AddAsync(campos);
            _db.SaveChanges();
            return campos;


        }*/

        public async Task<Campos> DeleteCampos(Campos campos)
        {
            _db.Campos.Attach(campos); //Llamamos la actualizacion
            _db.Entry(campos).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return campos;
        }

        public async Task<List<Campos>> GetAll()
        {
            return await _db.Campos.ToListAsync();
        }

        public async Task<Campos> GetCampos(int IdCampo)
        {
            return await _db.Campos.FirstOrDefaultAsync(c => c.IdCampo == IdCampo);
        }

        public async Task<Campos> UpdateCampos(Campos campos)
        {
            Campos ConsultUpdate = await _db.Campos.FindAsync(campos.IdCampo);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.NombreCampo = campos.NombreCampo;
                ConsultUpdate.Ubicacion = campos.Ubicacion;
                ConsultUpdate.Tamano = campos.Tamano;

                await _db.SaveChangesAsync();
            }
            return ConsultUpdate;

        }
    }
}
