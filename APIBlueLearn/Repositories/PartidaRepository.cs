using Microsoft.EntityFrameworkCore;
using APIBlueLearn.Context;
using APIBlueLearn.Model;


namespace APIBlueLearn.Repositories
{

    public interface IPartidaRepository
    {
        Task<List<Partida>> GetAll();
        Task<Partida> GetPartida(int IdPartida);
        Task<Partida> CreatePartida(string NombrePartida, int IdJugador, int IdLogro, int PuntajePartida);
        Task<Partida> UpdatePartida(Partida partida);
        Task<Partida> DeletePartida(Partida partida);
    }
    public class PartidaRepository : IPartidaRepository
    {
        private readonly BLDbContext _db;

        public PartidaRepository(BLDbContext db)
        {
            _db = db;
        }
        public async Task<Partida> CreatePartida(string NombrePartida, int IdJugador, int IdLogro, int PuntajePartida)
        {
            Partida newPartida = new Partida
            {
                NombrePartida = NombrePartida,
                IdJugador = IdJugador,
                IdLogro = IdLogro,
                PuntajePartida = PuntajePartida
            };
            await _db.Partida.AddAsync(newPartida);
            _db.SaveChanges();
            return newPartida;

        }

        /*public async Task<Partida> DeletePartida(Partida partida)
        {
            await _db.Partida.AddAsync(partida);
            _db.SaveChanges();
            return partida;
        }*/
        public async Task<Partida> DeletePartida(Partida partida)
        {
            _db.Partida.Attach(partida); //Llamamos la actualizacion
            _db.Entry(partida).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return partida;
        }

        public async Task<List<Partida>> GetAll()
        {
            return await _db.Partida.ToListAsync();
        }

        public async Task<Partida> GetPartida(int IdPartida)
        {
            return await _db.Partida.FirstOrDefaultAsync(a => a.IdPartida == IdPartida);
        }

        public async Task<Partida> UpdatePartida(Partida partida)
        {
            Partida ConsultUpdate = await _db.Partida.FindAsync(partida.IdPartida);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.NombrePartida = partida.NombrePartida;
                ConsultUpdate.IdJugador = partida.IdJugador;
                ConsultUpdate.IdLogro = partida.IdLogro;
                ConsultUpdate.PuntajePartida = partida.PuntajePartida;


                await _db.SaveChangesAsync();
            }

            return ConsultUpdate;
            //throw new NotImplementedException();
        }
    }
}
