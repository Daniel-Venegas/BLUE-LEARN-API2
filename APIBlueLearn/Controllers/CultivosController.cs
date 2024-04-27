using Microsoft.AspNetCore.Mvc;
using APIBlueLearn.Model;
using APIBlueLearn.Services;

namespace APIBlueLearn.Controllers
{

    [ApiController]

    [Route("api/[controller]")]
    public class CultivosController : ControllerBase
    {
        private readonly ICultivosService _cultivosService;

        public CultivosController(ICultivosService cultivosService)
        {
            _cultivosService = cultivosService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Cultivos>>> GetAll()
        {
            var cultivos = await _cultivosService.GetAll();
            var cultivosNoEliminados = cultivos.Where(a => !a.Eliminado).ToList();
            return Ok(cultivosNoEliminados);
        }



        [HttpGet("{IdCultivo}")]
        public async Task<ActionResult<Cultivos>> GetCultivos(int IdCultivo)
        {
            var Cultivos = await _cultivosService.GetCultivos(IdCultivo);
            if (Cultivos == null)
            {
                return BadRequest("User not found");
            }
            if (Cultivos.Eliminado == true)
            {
                return BadRequest("registro no valido");

            }
            return Ok(Cultivos);
        }


        [HttpPost]
        public async Task<ActionResult<Cultivos>> CreateCultivos([FromBody] Cultivos cultivos)
        {
            if (cultivos == null)
            {
                return BadRequest("El objeto cultivo es nulo.");
            }
            var newCultivos = await _cultivosService.CreateCultivos(cultivos.FechaPlantacion, cultivos.IdEstadoCultivo, cultivos.IdCampo);
            return Ok(newCultivos);
        }

        /*[HttpPut("{IdCultivo}")]
        public async Task<ActionResult<Cultivos>> UpdateCultivos(int IdCultivo, [FromBody] Cultivos UpdateCultivos)
        {
            if (UpdateCultivos == null || IdCultivo <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar");
            }
            var updateCultivos = await _cultivosService.UpdateCultivos(IdCultivo, UpdateCultivos.FechaPlantacion, UpdateCultivos.IdEstadoCultivo, UpdateCultivos.IdCampo);
            return Ok(updateCultivos);
        }*/
        [HttpPut("{IdCultivo}")]
        public async Task<ActionResult<Cosechas>> UpdateCultivos(int IdCultivo, DateTime FechaCosecha, int CantidadRecogida, int IdEstadoCultivo, int IdCampo /*[FromBody] Campos UpdateCampos*/)
        {
            var UpdateCultivos = await _cultivosService.UpdateCultivos(IdCultivo, FechaCosecha, CantidadRecogida, IdCultivo);
            if (UpdateCultivos != null)
            {
                return Ok(UpdateCultivos);
            }
            else
            {
                return BadRequest("");
            }


        }

        /*[HttpDelete("{IdCultivo}")]
        public async Task<ActionResult<Cultivos>> DeleteCultivos(int IdCultivo)
        {
            if (IdCultivo <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedCultivos = await _cultivosService.DeleteCultivos(IdCultivo);
            return Ok(DeletedCultivos);
        }*/

        [HttpDelete("Delete/{IdCultivo}")]
        public async Task<ActionResult<Agricultores>> DeleteCultivos(int IdCultivo)
        {

            var cultivosToDelete = await _cultivosService.DeleteCultivos(IdCultivo);

            if (cultivosToDelete != null)
            {
                return Ok(cultivosToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }


    }
}
