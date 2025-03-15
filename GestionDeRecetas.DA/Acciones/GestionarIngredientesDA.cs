
using GestionDeRecetas.BC.Modelos;
using GestionDeRecetas.BW.Interfaces.DA;
using GestionDeRecetas.DA.Config;
using Microsoft.EntityFrameworkCore;
using AppContext = GestionDeRecetas.DA.Config.AppContext;

namespace GestionDeRecetas.DA.Acciones
{
    public class GestionarIngredientesDA : IGestionarIngredienteDA
    {
        private readonly AppContext appContext;
        public GestionarIngredientesDA(AppContext context)
        {
            this.appContext = context;
        }

        public async Task<bool> actualizarIngrediente(int id, Ingrediente ingrediente)
        {
            Ingrediente ingredienteExistente = await appContext.Ingrediente.FindAsync(id);

            if (ingredienteExistente == null)
                return false;

            ingredienteExistente.Nombre = ingrediente.Nombre;
            ingredienteExistente.Unidad = ingrediente.Unidad;
            ingredienteExistente.Cantidad = ingrediente.Cantidad;
            ingredienteExistente.Costo = ingrediente.Costo;

            await appContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> eliminarIngrediente(int id)
        {
            var ingrediente = await appContext.Ingrediente.FindAsync(id);

            if (ingrediente == null)
                return false;

            appContext.Ingrediente.Remove(ingrediente);
            await appContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> obtenerIngrediente(int id)
        {
            var ingrediente = await appContext.Ingrediente.FindAsync(id);

            return ingrediente != null;
        }

        public async Task<List<Ingrediente>> obtenerIngredientes()
        {
            return await appContext.Ingrediente.ToListAsync();
        }

        public async Task<bool> registrarIngrediente(Ingrediente ingrediente)
        {
            try
            {
                appContext.Ingrediente.Add(ingrediente);

                await appContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
