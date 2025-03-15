using GestionDeRecetas.BC.Modelos;
using GestionDeRecetas.BW.Interfaces.BW;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeRecetas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecetaIngredienteController : ControllerBase
    {
        private readonly IGestionarRecetaIngredienteBW gestionarRecetaIngredienteBW;
        public RecetaIngredienteController(IGestionarRecetaIngredienteBW gestionarRecetaIngredienteBW)
        {
            this.gestionarRecetaIngredienteBW = gestionarRecetaIngredienteBW;
        }

        [HttpPut("{id}", Name = "ActualizarRecetaIngrediente")]
        public async Task<ActionResult<bool>> Put(int recetaId, int id, [FromBody] RecetaIngrediente recetaIngrediente)
        {
            try
            {
                if (id != recetaIngrediente.RecetaId)
                    return BadRequest("El ID del ingrediente no coincide con el parámetro proporcionado");
                var resultado = await gestionarRecetaIngredienteBW.actualizarRecetaIngrediente(recetaId, id, recetaIngrediente);
                if (!resultado)
                    return NotFound("Ingrediente no encontrado");
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno en el servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}", Name = "EliminarRecetaIngrediente")]
        public async Task<ActionResult<bool>> Delete(int recetaId, int id)
        {
            try
            {
                var resultado = await gestionarRecetaIngredienteBW.eliminarRecetaIngrediente(recetaId, id);
                if (!resultado)
                    return NotFound("Ingrediente no encontrado");
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno en el servidor: {ex.Message}");
            }
        }

        [HttpPost(Name = "RegistrarRecetaIngrediente")]
        public async Task<ActionResult<bool>> Post([FromBody] RecetaIngrediente recetaIngrediente)
        {
            try
            {
                return Ok(await gestionarRecetaIngredienteBW.registrarRecetaIngrediente(recetaIngrediente));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno en el servidor: {ex.Message}");
            }
        }
    }
}
