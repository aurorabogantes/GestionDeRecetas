
using GestionDeRecetas.BC.Modelos;
using GestionDeRecetas.BW.Interfaces.DA;
using AppContext = GestionDeRecetas.DA.Config.AppContext;

namespace GestionDeRecetas.DA.Acciones
{
    class GestionarRecetaIngredienteDA : IGestionarRecetaIngredienteDA
    {
        private readonly AppContext appContext;
        public GestionarRecetaIngredienteDA(AppContext context)
        {
            this.appContext = context;
        }
        public async Task<bool> actualizarRecetaIngrediente(int RecetaId, int IngredienteId, RecetaIngrediente recetaIngrediente)
        {
            RecetaIngrediente tablaExistente = await appContext.RecetaIngrediente.FindAsync(RecetaId, IngredienteId);

            if (tablaExistente == null)
            {
                return false;
            }

            tablaExistente.Cantidad = recetaIngrediente.Cantidad;
            tablaExistente.IngredienteId = recetaIngrediente.IngredienteId;
            tablaExistente.RecetaId = recetaIngrediente.RecetaId;

            await appContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> eliminarRecetaIngrediente(int IdReceta, int IdIngrediente)
        {
            var receta = await appContext.RecetaIngrediente.FindAsync(IdReceta);
            var ingrediente = await appContext.RecetaIngrediente.FindAsync(IdIngrediente);

            if (receta == null && ingrediente == null)
            {
                return false;
            }

            appContext.RecetaIngrediente.Remove(receta);
            appContext.RecetaIngrediente.Remove(ingrediente);
            await appContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> registrarRecetaIngrediente(RecetaIngrediente recetaIngrediente)
        {
            try
            {
                appContext.RecetaIngrediente.Add(recetaIngrediente);

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
