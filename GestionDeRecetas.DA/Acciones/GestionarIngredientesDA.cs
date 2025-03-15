
using GestionDeRecetas.BC.Modelos;
using GestionDeRecetas.BW.Interfaces.DA;
using GestionDeRecetas.DA.Config;
using Microsoft.EntityFrameworkCore;

namespace GestionDeRecetas.DA.Acciones
{
    public class GestionarIngredientesDA : IGestionarIngredienteDA
    {
        private readonly GestionDeIngredienteContext gestionDeIngredienteContext;
        public GestionarIngredientesDA(GestionDeIngredienteContext context)
        {
            this.gestionDeIngredienteContext = context;
        }

        public async Task<bool> actualizarIngrediente(int id, Ingrediente ingrediente)
        {
            Ingrediente ingredienteExistente = await gestionDeIngredienteContext.Ingrediente.FindAsync(id);

            if (ingredienteExistente == null)
                return false;

            ingredienteExistente.Nombre = ingrediente.Nombre;
            ingredienteExistente.Unidad = ingrediente.Unidad;
            ingredienteExistente.Cantidad = ingrediente.Cantidad;
            ingredienteExistente.Costo = ingrediente.Costo;

            await gestionDeIngredienteContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> eliminarIngrediente(int id)
        {
            var ingrediente = await gestionDeIngredienteContext.Ingrediente.FindAsync(id);

            if (ingrediente == null)
                return false;

            gestionDeIngredienteContext.Ingrediente.Remove(ingrediente);
            await gestionDeIngredienteContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> obtenerIngrediente(int id)
        {
            var ingrediente = await gestionDeIngredienteContext.Ingrediente.FindAsync(id);

            return ingrediente != null;
        }

        public async Task<List<Ingrediente>> obtenerIngredientes()
        {
            return await gestionDeIngredienteContext.Ingrediente.ToListAsync();
        }

        public async Task<bool> registrarIngrediente(Ingrediente ingrediente)
        {
            try
            {
                gestionDeIngredienteContext.Ingrediente.Add(ingrediente);

                await gestionDeIngredienteContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
