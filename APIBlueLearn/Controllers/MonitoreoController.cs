using Microsoft.AspNetCore.Mvc;
using APIBlueLearn.Model;
using APIBlueLearn.Services;

namespace APIBlueLearn.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MonitoreoController : ControllerBase
    {

        private readonly IMonitoreoService _monitoreoService;

        public MonitoreoController(IMonitoreoService monitoreoService)
        {
            _monitoreoService = monitoreoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Monitoreo>>> GetAll()
        {
            var monitoreo = await _monitoreoService.GetAll();
            var monitoreoNoEliminados = monitoreo.Where(a => !a.Eliminado).ToList();
            return Ok(monitoreoNoEliminados);
        }

        [HttpGet("{IdMonitoreo}")]
        public async Task<ActionResult<Monitoreo>> GetMonitoreo(int IdMonitoreo)
        {
            var Monitoreo = await _monitoreoService.GetMonitoreo(IdMonitoreo);
            if (Monitoreo == null)
            {
                return BadRequest("user not found");
            }
            if (Monitoreo.Eliminado == true)
            {
                return BadRequest("registro no valido");

            }
            return Ok(Monitoreo);
        }

        [HttpPost]
        public async Task<ActionResult<Monitoreo>> CreateMonitoreo([FromBody] Monitoreo monitoreo)
        {
            if (monitoreo == null)
            {
                return BadRequest("El objeto es nulo");
            }
            var newMonitoreo = await _monitoreoService.CreateMonitoreo(monitoreo.FechaMonitoreo, monitoreo.Valor, monitoreo.IdDescripcionMonitoreo, monitoreo.IdCultivo);
            return Ok(newMonitoreo);
        }

        [HttpPut("{IdMonitoreo}")]
        public async Task<ActionResult<Monitoreo>> UpdateMonitoreo(int IdMonitoreo, [FromBody] Monitoreo UpdateMonitoreo)
        {
            if (UpdateMonitoreo == null || IdMonitoreo <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar");
            }
            var updateMonitoreo = await _monitoreoService.UpdateMonitoreo(IdMonitoreo, UpdateMonitoreo.FechaMonitoreo, UpdateMonitoreo.Valor, UpdateMonitoreo.IdDescripcionMonitoreo, UpdateMonitoreo.IdCultivo);
            return Ok(updateMonitoreo);
        }

        /*[HttpDelete("{IdMonitoreo}")]
        public async Task<ActionResult<Monitoreo>> DeleteMonitoreo(int IdMonitoreo)
        {
            if (IdMonitoreo <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedMonitoreo = await _monitoreoService.DeleteMonitoreo(IdMonitoreo);
            return Ok(DeletedMonitoreo);
        }*/

        [HttpDelete("Delete/{IdMonitoreo}")]
        public async Task<ActionResult<Agricultores>> DeleteMonitoreo(int IdMonitoreo)
        {

            var monitoreoToDelete = await _monitoreoService.DeleteMonitoreo(IdMonitoreo);

            if (monitoreoToDelete != null)
            {
                return Ok(monitoreoToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }
}
