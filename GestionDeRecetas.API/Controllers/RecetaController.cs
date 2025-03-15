using GestionDeRecetas.BC.Modelos;
using GestionDeRecetas.BW.Interfaces.BW;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeRecetas.Controllers;

[ApiController]
[Route("[controller]")]
public class RecetaController : ControllerBase
{
    private readonly IGestionarRecetasBW gestionarRecetasBW;
    public RecetaController(IGestionarRecetasBW gestionarRecetasBW)
    {
        this.gestionarRecetasBW = gestionarRecetasBW;
    }

    [HttpGet(Name = "GetRecetas")]
    public async Task<ActionResult<IEnumerable<Receta>>> Get()
    {
        try
        {
            var recetas = await gestionarRecetasBW.obtenerRecetas();

            return Ok(recetas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno en el servidor: {ex.Message}");
        }
    }

    [HttpGet("{id}", Name = "GetReceta")]
    public async Task<ActionResult<bool>> Get(int id)
    {
        try
        {
            var resultado = await gestionarRecetasBW.obtenerReceta(id);

            if (!resultado)
                return NotFound("Receta no encontrada");

            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno en el servidor: {ex.Message}");
        }
    }

    [HttpPut("{id}", Name = "ActualizarReceta")]
    public async Task<ActionResult<bool>> Put(int id, [FromBody] Receta receta)
    {
        try
        {
            if (id != receta.Id)
                return BadRequest("El ID del producto no coincide con el parámetro proporcionado");

            var resultado = await gestionarRecetasBW.actualizarReceta(id, receta);

            if (!resultado)
                return NotFound("Receta no encontrada");

            return Ok(true);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }

    [HttpDelete("{id}", Name = "EliminarReceta")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        try
        {
            var resultado = await gestionarRecetasBW.eliminarReceta(id);

            if (!resultado)
                return NotFound("Producto no encontrado");

            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno en el servidor: {ex.Message}");
        }
    }

    [HttpPost(Name = "RegistrarReceta")]
    public async Task<ActionResult<bool>> Post([FromBody] Receta receta)
    {
        try
        {
            return Ok(await gestionarRecetasBW.registrarReceta(receta));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno en el servidor: {ex.Message}");
        }
    }
}
