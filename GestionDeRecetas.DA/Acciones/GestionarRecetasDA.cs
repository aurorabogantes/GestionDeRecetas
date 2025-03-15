
using GestionDeRecetas.BC.Modelos;
using GestionDeRecetas.BW.CU;
using GestionDeRecetas.BW.Interfaces.DA;
using GestionDeRecetas.DA.Config;
using GestionDeRecetas.DA.Entidades;
using Microsoft.EntityFrameworkCore;
using AppContext = GestionDeRecetas.DA.Config.AppContext;

namespace GestionDeRecetas.DA.Acciones
{
    public class GestionarRecetasDA : IGestionarRecetasDA
    {
        private readonly AppContext appContext;

        public GestionarRecetasDA(AppContext context)
        {
            this.appContext = context;
        }

        public async Task<bool> actualizarReceta(int id, Receta receta)
        {
            Receta recetaExistente = await appContext.Receta.FindAsync(id);

            if (recetaExistente == null)
                return false;

            recetaExistente.Nombre = receta.Nombre;
            recetaExistente.Descripcion = receta.Descripcion;
            recetaExistente.Instrucciones = receta.Instrucciones;
            recetaExistente.Tiempo = receta.Tiempo;
            recetaExistente.Categoria = receta.Categoria;
            recetaExistente.Foto = receta.Foto;

            await appContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> eliminarReceta(int id)
        {
            var receta = await appContext.Receta.FindAsync(id);

            if (receta == null)
                return false;

            appContext.Receta.Remove(receta);
            await appContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> obtenerReceta(int id)
        {
            var receta = await appContext.Receta.FindAsync(id);

            return receta != null;
        }

        public async Task<List<Receta>> obtenerRecetas()
        {
            return await appContext.Receta.ToListAsync();
        }

        public async Task<bool> registrarReceta(Receta receta)
        {
            try
            {
                appContext.Receta.Add(receta);

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
