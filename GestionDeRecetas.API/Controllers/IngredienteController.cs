using GestionDeRecetas.BC.Modelos;
using GestionDeRecetas.BW.Interfaces.BW;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeRecetas.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class IngredienteController : ControllerBase
    {
        private readonly IGestionarIngredientesBW gestionarIngredientesBW;
        public IngredienteController(IGestionarIngredientesBW gestionarIngredientesBW)
        {
            this.gestionarIngredientesBW = gestionarIngredientesBW;
        }

        [HttpGet(Name = "GetIngredientes")]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> Get()
        {
            try
            {
                var ingredientes = await gestionarIngredientesBW.obtenerIngredientes();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno en el servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetIngrediente")]
        public async Task<ActionResult<bool>> Get(int id)
        {
            try
            {
                var resultado = await gestionarIngredientesBW.obtenerIngrediente(id);

                if (!resultado)
                    return NotFound("Ingrediente no encontrado");

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errpr interno en el sevidor: {ex.Message}");
            }
        }

        [HttpPut("{id}", Name = "ActualizarIngrediente")]
        public async Task<ActionResult<bool>> Put(int id, [FromBody] Ingrediente ingrediente)
        {
            try
            {
                if (id != ingrediente.Id)
                    return BadRequest("El ID del ingrediente no coincide con el parámetro proporcionado");

                var resultado = await gestionarIngredientesBW.actualizarIngrediente(id, ingrediente);

                if (!resultado)
                    return NotFound("Ingrediente no encontrado");

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno en el servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}", Name = "EliminarIngrediente")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var resultado = await gestionarIngredientesBW.eliminarIngrediente(id);

                if (!resultado)
                    return NotFound("Ingrediente no encontrado");

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno en el servidor: {ex.Message}");
            }
        }

        [HttpPost(Name = "RegistrarIngrediente")]
        public async Task<ActionResult<bool>> Post([FromBody] Ingrediente ingrediente)
        {
            try
            {
                return Ok(await gestionarIngredientesBW.registrarIngrediente(ingrediente));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno en el servidor: {ex.Message}");
            }
        }
    }
}
