using Microsoft.AspNetCore.Mvc;
using APIBlueLearn.Model;
using APIBlueLearn.Services;

namespace APIBlueLearn.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PartidaController : ControllerBase
    {
        private readonly IPartidaService _partidaService;

        public PartidaController(IPartidaService partidaService)
        {
            _partidaService = partidaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Partida>>> GetAll()
        {
            var partida = await _partidaService.GetAll();
            var partidaNoEliminados = partida.Where(a => !a.Eliminado).ToList();
            return Ok(partidaNoEliminados);
        }

        [HttpGet("{IdPartida}")]
        public async Task<ActionResult<Partida>> GetPartida(int IdPartida)
        {
            var Partida = await _partidaService.GetPartida(IdPartida);
            if (Partida == null)
            {
                return BadRequest("User not found");
            }
            if (Partida.Eliminado == true)
            {
                return BadRequest("registro no valido");

            }
            return Ok(Partida);
        }

        [HttpPost]
        public async Task<ActionResult<Partida>> CreatePartida([FromBody] Partida partida)
        {
            if (partida == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var newPartida = await _partidaService.CreatePartida(partida.NombrePartida, partida.IdJugador, partida.IdLogro, partida.PuntajePartida);
            return Ok(newPartida);
        }

        [HttpPut("{IdPartida}")]
        public async Task<ActionResult<Partida>> UpdatePartida(int IdPartida, [FromBody] Partida UpdatePartida)
        {
            if (UpdatePartida == null || IdPartida <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar");
            }
            var updatePartida = await _partidaService.UpdatePartida(IdPartida, UpdatePartida.NombrePartida, UpdatePartida.IdJugador, UpdatePartida.IdLogro, UpdatePartida.PuntajePartida);
            return Ok(updatePartida);
        }

        /*[HttpDelete("{IdPartida}")]
        public async Task<ActionResult<Partida>> DeletePartida(int IdPartida)
        {
            if (IdPartida <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedPartida = await _partidaService.DeletePartida(IdPartida);
            return Ok(DeletedPartida);
        }*/

        [HttpDelete("Delete/{IdPartida}")]
        public async Task<ActionResult<Agricultores>> DeletePartida(int IdPartida)
        {

            var partidaToDelete = await _partidaService.DeletePartida(IdPartida);

            if (partidaToDelete != null)
            {
                return Ok(partidaToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }


    }
}
