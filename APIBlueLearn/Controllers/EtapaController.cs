using Microsoft.AspNetCore.Mvc;
using APIBlueLearn.Model;
using APIBlueLearn.Services;

namespace APIBlueLearn.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EtapaController : ControllerBase
    {

        private readonly IEtapaService _etapaService;

        public EtapaController(IEtapaService etapaService)
        {
            _etapaService = etapaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Etapa>>> GetAll()
        {
            var etapa = await _etapaService.GetAll();
            var etapaNoEliminados = etapa.Where(a => !a.Eliminado).ToList();
            return Ok(etapaNoEliminados);
        }

        [HttpGet("{IdEtapa}")]
        public async Task<ActionResult<Etapa>> GetEtapa(int IdEtapa)
        {
            var Etapa = await _etapaService.GetEtapa(IdEtapa);
            if (Etapa == null)
            {
                return BadRequest("User not found");
            }
            if (Etapa.Eliminado == true)
            {
                return BadRequest("registro no valido");

            }
            return Ok(Etapa);
        }

        [HttpPost]
        public async Task<ActionResult<Etapa>> CreateEtapa([FromBody] Etapa etapa)
        {
            if (etapa == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var newEtapa = await _etapaService.CreateEtapa(etapa.Descripcion);
            return Ok(newEtapa);
        }

        [HttpPut("{IdEtapa}")]
        public async Task<ActionResult<Etapa>> UpdateEtapa(int IdEtapa, [FromBody] Etapa UpdateEtapa)
        {
            if (UpdateEtapa == null || IdEtapa <= 0)
            {
                return BadRequest("Datos de entrada invalidos");
            }
            var updateEtapa = await _etapaService.UpdateEtapa(IdEtapa, UpdateEtapa.Descripcion);
            return Ok(updateEtapa);
        }

        /*[HttpDelete("{IdEtapa}")]
        public async Task<ActionResult<Etapa>> DeleteEtapa(int IdEtapa)
        {
            if (IdEtapa <= 0)
            {
                return Ok("Id invalido para eliminar");
            }
            var DeletedEtapa = await _etapaService.DeleteEtapa(IdEtapa);
            return Ok(DeletedEtapa);
        }*/

        [HttpDelete("Delete/{IdEtapa}")]
        public async Task<ActionResult<Agricultores>> DeleteEtapa(int IdEtapa)
        {

            var etapaToDelete = await _etapaService.DeleteEtapa(IdEtapa);

            if (etapaToDelete != null)
            {
                return Ok(etapaToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }
}
