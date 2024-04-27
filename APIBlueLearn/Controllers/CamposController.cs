using APIBlueLearn.Model;
using APIBlueLearn.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIBlueLearn.Controllers
{


    [ApiController]

    [Route("api/[controller]")]
    public class CamposController : ControllerBase
    {

        private readonly ICampoService _campoService;

        public CamposController(ICampoService campoService)
        {
            _campoService = campoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Campos>>> GetAll()
        {
            var campos = await _campoService.GetAll();
            var camposNoEliminados = campos.Where(a => !a.Eliminado).ToList();
            return Ok(camposNoEliminados);
        }

        [HttpGet("{IdCampo}")]
        
        public async Task<ActionResult<Campos>> GetCampos(int IdCampo)
        {
            var Campos = await _campoService.GetCampos(IdCampo);
            if (Campos == null)
            {
                return BadRequest("user not found");
            }
            if (Campos.Eliminado == true)
            {
                return BadRequest("registro no valido");

            }
            return Ok(Campos);
        }

        [HttpPost]
        public async Task<ActionResult<Campos>> CreateCampos([FromBody] Campos campos)
        {
            if (campos == null)
            {
                return BadRequest("El objeto agricultores es nulo");
            }
            var newCampos = await _campoService.CreateCampos(campos.NombreCampo, campos.Ubicacion, campos.Tamano);
            return Ok(newCampos);


        }
        [HttpPut("{IdCampo}")]
        public async Task<ActionResult<Campos>> UpdateCampos(int IdCampo, string NombreCampo, string Ubicacion, int Tamano /*[FromBody] Campos UpdateCampos*/)
        {
            var UpdateCampos = await _campoService.UpdateCampos(IdCampo, NombreCampo, Ubicacion, Tamano);
            if (UpdateCampos != null)
            {
                return Ok(UpdateCampos);
            }
            else
            {
                return BadRequest("");
            }
                
            
        }



        /*[HttpDelete("{IdCampos}")]
        public async Task<ActionResult<Campos>> DeleteCampos(int IdCampo)
        {
            if (IdCampo <= 0)
            {
                return BadRequest("Id invalido para eliminar");
            }
            var DeletedCampos = await _campoService.DeleteCampos(IdCampo);
            return Ok(DeletedCampos);
        }*/

        [HttpDelete("Delete/{IdCampo}")]
        public async Task<ActionResult<Agricultores>> DeleteCampos(int IdCampo)
        {

            var camposToDelete = await _campoService.DeleteCampos(IdCampo);

            if (camposToDelete != null)
            {
                return Ok(camposToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }
}
