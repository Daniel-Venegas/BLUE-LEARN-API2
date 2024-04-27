using APIBlueLearn.Model;
using APIBlueLearn.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIBlueLearn.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TemporadaController : ControllerBase
    {
        private readonly TemporadaService _temporadaService;

        public TemporadaController(TemporadaService temporadaService)
        {
            _temporadaService = temporadaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Temporadas>>> GetAll()
        {
            var temporadas = await _temporadaService.GetAll();
            var temporadasNoEliminados = temporadas.Where(a => !a.Eliminado).ToList();
            return Ok(temporadasNoEliminados);

        }

        [HttpGet("{IdTemporada}")]
        public async Task<ActionResult<Temporadas>> GetTemporadas(int IdTemporada)
        {
            var Temporadas = await _temporadaService.GetTemporadas(IdTemporada);
            if (Temporadas == null)
            {
                return BadRequest("User not found");

            }
            if (Temporadas.Eliminado == true)
            {
                return BadRequest("registro no valido");

            }
            return Ok(Temporadas);
        }

        [HttpPost]
        public async Task<ActionResult<Temporadas>> CreateTemporadas([FromBody] Temporadas temporadas)
        {
            if (temporadas == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var newTemporadas = await _temporadaService.CreateTemporadas(temporadas.Temporada);
            return Ok(newTemporadas);
        }

        [HttpPut("{IdTemporada}")]
        public async Task<ActionResult<Temporadas>> UpdateTemporadas(int IdTemporada, [FromBody] Temporadas UpdateTemporadas)
        {
            if (UpdateTemporadas == null || IdTemporada <= 0)
            {
                return BadRequest("Datos de entrada no validos para actualizar");
            }
            var updateTemporadas = await _temporadaService.UpdateTemporadas(IdTemporada, UpdateTemporadas.Temporada);
            return Ok(updateTemporadas);
        }

        /*[HttpDelete("{IdTemporada}")]
        public async Task<ActionResult<Temporadas>> DeleteTemporadas(int IdTemporada)
        {
            if (IdTemporada <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedTemporadas = await _temporadaService.DeleteTemporadas(IdTemporada);
            return Ok(DeletedTemporadas);
        }*/

        [HttpDelete("Delete/{IdTemporada}")]
        public async Task<ActionResult<Agricultores>> DeleteTemporada(int IdTemporada)
        {

            var temporadaToDelete = await _temporadaService.DeleteTemporadas(IdTemporada);

            if (temporadaToDelete != null)
            {
                return Ok(temporadaToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }
}
