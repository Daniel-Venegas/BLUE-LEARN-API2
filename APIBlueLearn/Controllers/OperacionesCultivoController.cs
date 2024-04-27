using Microsoft.AspNetCore.Mvc;
using APIBlueLearn.Model;
using APIBlueLearn.Services;

namespace APIBlueLearn.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OperacionesCultivoController : ControllerBase
    {
        private readonly IOperacionesCultivoService _operacionesCultivoService;

        public OperacionesCultivoController(IOperacionesCultivoService operacionesCultivoService)
        {
            _operacionesCultivoService = operacionesCultivoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OperacionesCultivo>>> GetAll()
        {
            var operacionesCultivo = await _operacionesCultivoService.GetAll();
            var operacionesCultivoNoEliminados = operacionesCultivo.Where(a => !a.Eliminado).ToList();
            return Ok(operacionesCultivoNoEliminados);
        }

        [HttpGet("{IdOperacion}")]
        public async Task<ActionResult<OperacionesCultivo>> GetOperacionesCultivo(int IdOperacion)
        {
            var OperacionesCultivo = await _operacionesCultivoService.GetOperacionesCultivo(IdOperacion);
            if (OperacionesCultivo == null)
            {
                return BadRequest("User not found");
            }
            if (OperacionesCultivo.Eliminado == true)
            {
                return BadRequest("registro no valido");

            }
            return Ok(OperacionesCultivo);

        }

        [HttpPost]
        public async Task<ActionResult<OperacionesCultivo>> CreateOperacionesCultivo([FromBody] OperacionesCultivo operacionesCultivo)
        {
            if (operacionesCultivo == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var newOperacionesCultivo = await _operacionesCultivoService.CreateOperacionesCultivo(operacionesCultivo.IdEstadoOperacion, operacionesCultivo.FechaOperacion, operacionesCultivo.Descripcion, operacionesCultivo.IdCultivo, operacionesCultivo.IdAgricultor);
            return Ok(newOperacionesCultivo);
        }

        [HttpPut("{IdOperacion}")]
        public async Task<ActionResult<OperacionesCultivo>> UpdateOperacionesCultivo(int IdOperacion, [FromBody] OperacionesCultivo UpdateOperacionesCultivo)
        {
            if (UpdateOperacionesCultivo == null || IdOperacion <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar");
            }
            var updateOperacionesCultivo = await _operacionesCultivoService.UpdateOperacionesCultivo(IdOperacion, UpdateOperacionesCultivo.IdEstadoOperacion, UpdateOperacionesCultivo.FechaOperacion, UpdateOperacionesCultivo.Descripcion, UpdateOperacionesCultivo.IdCultivo, UpdateOperacionesCultivo.IdAgricultor);
            return Ok(updateOperacionesCultivo);
        }

        /*[HttpDelete("{IdOperacion}")]
        public async Task<ActionResult<OperacionesCultivo>> DeleteOperacionesCultivo(int IdOperacion)
        {
            if (IdOperacion <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedOperacionesCultivo = await _operacionesCultivoService.DeleteOperacionesCultivo(IdOperacion);
            return Ok(DeletedOperacionesCultivo);
        }*/

        [HttpDelete("Delete/{IdOperacion}")]
        public async Task<ActionResult<Agricultores>> DeleteOperacionesCultivo(int IdOperacion)
        {

            var operacionToDelete = await _operacionesCultivoService.DeleteOperacionesCultivo(IdOperacion);

            if (operacionToDelete != null)
            {
                return Ok(operacionToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }
}
