using Microsoft.AspNetCore.Mvc;
using APIBlueLearn.Model;
using APIBlueLearn.Services;

namespace APIBlueLearn.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LogroController : ControllerBase
    {
        private readonly ILogroService _logroService;

        public LogroController(ILogroService logroService)
        {
            _logroService = logroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Logro>>> GetAll()
        {
            var logro = await _logroService.GetAll();
            var logroNoEliminados = logro.Where(a => !a.Eliminado).ToList();
            return Ok(logroNoEliminados);
        }

        [HttpGet("{IdLogro}")]
        public async Task<ActionResult<Logro>> GetLogro(int IdLogro)
        {
            var Logro = await _logroService.GetLogro(IdLogro);
            if (Logro == null)
            {
                return BadRequest("User not found");
            }
            if (Logro.Eliminado == true)
            {
                return BadRequest("registro no valido");

            }
            return Ok(Logro);
        }

        [HttpPost]
        public async Task<ActionResult<Logro>> CreateLogro([FromBody] Logro logro)
        {
            if (logro == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var newLogro = await _logroService.CreateLogro(logro.Descripcion, logro.Fecha, logro.Puntos);
            return Ok(newLogro);
        }

        [HttpPut("{IdLogro}")]
        public async Task<ActionResult<Logro>> UpdateLogro(int IdLogro, [FromBody] Logro UpdateLogro)
        {
            if (UpdateLogro == null || IdLogro <= 0)
            {
                return BadRequest("Datos nos encontrados para actualizar");
            }
            var updateLogro = await _logroService.UpdateLogro(IdLogro, UpdateLogro.Descripcion, UpdateLogro.Fecha, UpdateLogro.Puntos);
            return Ok(updateLogro);
        }

        /*[HttpDelete("{IdLogro}")]
        public async Task<ActionResult<Logro>> DeleteLogro(int IdLogro)
        {
            if (IdLogro <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedLogro = await _logroService.DeleteLogro(IdLogro);
            return Ok(DeletedLogro);
        }*/

        [HttpDelete("Delete/{IdLogro}")]
        public async Task<ActionResult<Agricultores>> DeleteLogro(int IdLogro)
        {

            var logroToDelete = await _logroService.DeleteLogro(IdLogro);

            if (logroToDelete != null)
            {
                return Ok(logroToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }
}
