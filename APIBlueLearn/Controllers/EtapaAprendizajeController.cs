using APIBlueLearn.Model;
using APIBlueLearn.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIBlueLearn.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EtapaAprendizajeController : ControllerBase
    {

        private readonly IEtapaAprendizajeService _etapaAprendizajeService;

        public EtapaAprendizajeController(IEtapaAprendizajeService etapaAprendizajeService)
        {
            _etapaAprendizajeService = etapaAprendizajeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EtapaAprendizaje>>> GetAll()
        {
            var etapaAprendizaje = await _etapaAprendizajeService.GetAll();
            var etapaAprendizajeNoEliminados = etapaAprendizaje.Where(a => !a.Eliminado).ToList();
            return Ok(etapaAprendizajeNoEliminados);
        }

        [HttpGet("{IdEstado}")]
        public async Task<ActionResult<EtapaAprendizaje>> GetEtapaAprendizaje(int IdEstado)
        {
            var EtapaAprendizaje = await _etapaAprendizajeService.GetEtapaAprendizaje(IdEstado);
            if (EtapaAprendizaje == null)
            {
                return BadRequest("user not found");
            }
            if (EtapaAprendizaje.Eliminado == true)
            {
                return BadRequest("registro no valido");

            }
            return Ok(EtapaAprendizaje);
        }

        [HttpPost]
        public async Task<ActionResult<EtapaAprendizaje>> CreateEtapaAprendizaje([FromBody] EtapaAprendizaje etapaAprendizaje)
        {
            if (etapaAprendizaje == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var newEtapaAprendizaje = await _etapaAprendizajeService.CreateEtapaAprendizaje(etapaAprendizaje.IdAgricultor, etapaAprendizaje.IdEtapa, etapaAprendizaje.FechaInit, etapaAprendizaje.FechaFin);
            return Ok(newEtapaAprendizaje);
        }

        [HttpPut("{IdEstado}")]
        public async Task<ActionResult<EtapaAprendizaje>> UpdateEtapaAprendizaje(int IdEstado, [FromBody] EtapaAprendizaje UpdateEtapaAprendizaje)
        {
            if (UpdateEtapaAprendizaje == null || IdEstado <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar");
            }
            var updateEtapaAprendizaje = await _etapaAprendizajeService.UpdateEtapaAprendizaje(IdEstado, UpdateEtapaAprendizaje.IdAgricultor, UpdateEtapaAprendizaje.IdEtapa, UpdateEtapaAprendizaje.FechaInit, UpdateEtapaAprendizaje.FechaFin);
            return Ok(updateEtapaAprendizaje);
        }

        /*[HttpDelete("{IdEstado}")]
        public async Task<ActionResult<EtapaAprendizaje>> DeleteEtapaAprendizaje(int IdEstado)
        {
            if (IdEstado <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedEtapaAprendizaje = await _etapaAprendizajeService.DeleteEtapaAprendizaje(IdEstado);
            return Ok(DeletedEtapaAprendizaje);
        }*/

        [HttpDelete("Delete/{IdEstado}")]
        public async Task<ActionResult<Agricultores>> DeleteEtapaAprendizaje(int IdEstado)
        {

            var etapaAprendizajeToDelete = await _etapaAprendizajeService.DeleteEtapaAprendizaje(IdEstado);

            if (etapaAprendizajeToDelete != null)
            {
                return Ok(etapaAprendizajeToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }


    }


}
