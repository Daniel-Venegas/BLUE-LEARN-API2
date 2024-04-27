using APIBlueLearn.Model;
using APIBlueLearn.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIBlueLearn.Controllers
{
    [ApiController]

    [Route("api/[controller]")]

    public class AgricultoresController : ControllerBase
    {

        private readonly IAgricultoresService _agricultoresService;

        public AgricultoresController(IAgricultoresService agricultoresService)
        {
            _agricultoresService = agricultoresService;
        }

        [HttpGet]
        /*public async Task<ActionResult<List<Agricultores>>> GetAll()
        {
            return Ok(await _agricultoresService.GetAll());
        }*/

        public async Task<ActionResult<List<Agricultores>>> GetAll()
        {
            var agricultores = await _agricultoresService.GetAll();
            var agricultoresNoEliminados = agricultores.Where(a => !a.Eliminado).ToList();
            return Ok(agricultoresNoEliminados);
        }


        [HttpGet("{IdAgricultor}")]
        public async Task<ActionResult<Agricultores>> GetAgricultores(int IdAgricultor)
        {

            var Agricultores = await _agricultoresService.GetAgricultor(IdAgricultor);

            if (Agricultores == null)
            {
                return BadRequest("user not found");
            }
            if (Agricultores.Eliminado == true)
            {
                return BadRequest("registro no valido");

            }
            return Ok(Agricultores);
        }

        [HttpPost]
        public async Task<ActionResult<Agricultores>> CreateAgricultores([FromBody] Agricultores agricultores)
        {
            if (agricultores == null)
            {
                return BadRequest("El objeto agricultores es nulo");
            }
            var newAgricultores = await _agricultoresService.CreateAgricultor(agricultores.IdJugador, agricultores.Nombres, agricultores.Apellidos, agricultores.Direccion, agricultores.Contacto, agricultores.Jugador);
            return Ok(newAgricultores);


        }
        /*[HttpPut("{IdAgricultor}")]
        public async Task<ActionResult<Agricultores>> UpdateAgricultores(int IdAgricultor, [FromBody] Agricultores UpdateAgricultores)
        {
            if (UpdateAgricultores == null || IdAgricultor <= 0)
            {
                return BadRequest("Datos de entrada inválidos para actualizar");
            }
            var updateAgricultores = await _agricultoresService.UpdateAgricultor(IdAgricultor, UpdateAgricultores.IdJugador, UpdateAgricultores.Nombres, UpdateAgricultores.Apellidos, UpdateAgricultores.Direccion, UpdateAgricultores.Contacto);
            return Ok(updateAgricultores);
        }*/

        [HttpPut("{IdAgricultor}")]
        public async Task<ActionResult<Agricultores>> UpdateAgricultores(int IdAgricultor, int IdJugador, string Nombres, string Apellidos, string Direccion,string Contacto)
        {
            var UpdateAgricultores = await _agricultoresService.UpdateAgricultor(IdAgricultor, IdJugador, Nombres, Apellidos, Direccion, Contacto);
            if (UpdateAgricultores != null)
            {
                return Ok(UpdateAgricultores);
            }
            else
            {
                return BadRequest("Error");
            }


        }

        /*[HttpDelete("{IdAgricultor}")]
        public async Task<ActionResult<Agricultores>> DeleteAgricultores(int IdAgricultor)
        {
            var Agricultores = await _agricultoresService.GetAgricultor(IdAgricultor);
            if (Agricultores != null)
            {
                Agricultores.Eliminado = true;
            }
            
            return Ok(Agricultores);
        }*/

        [HttpDelete("Delete/{IdAgricultor}")]
        public async Task<ActionResult<Agricultores>> DeleteAgricultores(int IdAgricultor)
        {

            var agricultoresToDelete = await _agricultoresService.DeleteAgricultor(IdAgricultor);

            if (agricultoresToDelete != null)
            {
                return Ok(agricultoresToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }
}
