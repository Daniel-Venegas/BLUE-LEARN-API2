using APIBlueLearn.Context;
using APIBlueLearn.Model;
using Microsoft.EntityFrameworkCore;

namespace APIBlueLearn.Repositories
{

    public interface IAgricultoresRepository
    {
        Task<List<Agricultores>> GetAll();
        Task<Agricultores> GetAgricultor(int IdAgricultor);
        Task<Agricultores> CreateAgricultor(int IdJugador, string Nombres, string Apellidos, string Direccion, string Contacto, Jugador jugador);
        Task<Agricultores> UpdateAgricultor(Agricultores agricultores);
        Task<Agricultores> DeleteAgricultor(Agricultores agricultores);
    }
    public class AgricultoresRepository : IAgricultoresRepository
    {

        private readonly BLDbContext _db;

        public AgricultoresRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<Agricultores> CreateAgricultor(int IdJugador, string Nombres, string Apellidos, string Direccion, string Contacto, Jugador jugador)
        {
            Agricultores newAgricultores = new Agricultores
            {
                IdJugador = IdJugador,
                Nombres = Nombres,
                Apellidos = Apellidos,
                Direccion = Direccion,
                Contacto = Contacto,
                Jugador = jugador

            };
            await _db.Agricultores.AddAsync(newAgricultores);
            _db.SaveChanges();
            return newAgricultores;


        }

        /*public async Task<Agricultores> DeleteAgricultor(Agricultores agricultores)
        {
            var agricultorExistente = await _db.Agricultores.FindAsync(agricultores.IdAgricultor);
            if(agricultorExistente != null)
            {
                agricultorExistente.Eliminado = true;
                await _db.SaveChangesAsync();
            }
            return agricultorExistente;
        }*/

        public async Task<Agricultores> DeleteAgricultor(Agricultores agricultores)
        {
            _db.Agricultores.Attach(agricultores); //Llamamos la actualizacion
            _db.Entry(agricultores).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return agricultores;
        }

        public async Task<Agricultores> GetAgricultor(int IdAgricultor)
        {
            return await _db.Agricultores.FirstOrDefaultAsync(a => a.IdAgricultor == IdAgricultor);
        }

        public async Task<List<Agricultores>> GetAll()
        {
            return await _db.Agricultores.ToListAsync();
        }

        public async Task<Agricultores> UpdateAgricultor(Agricultores agricultores)
        {
            Agricultores ConsultUpdate = await _db.Agricultores.FindAsync(agricultores.IdAgricultor);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.IdJugador = agricultores.IdJugador;
                ConsultUpdate.Nombres = agricultores.Nombres;
                ConsultUpdate.Apellidos = agricultores.Apellidos;
                ConsultUpdate.Direccion = agricultores.Direccion;
                ConsultUpdate.Contacto = agricultores.Contacto;


                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}
