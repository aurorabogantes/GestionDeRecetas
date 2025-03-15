
using GestionDeRecetas.BC.Modelos;
using GestionDeRecetas.BW.CU;
using GestionDeRecetas.BW.Interfaces.DA;
using GestionDeRecetas.DA.Config;
using GestionDeRecetas.DA.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GestionDeRecetas.DA.Acciones
{
    public class GestionarRecetasDA : IGestionarRecetasDA
    {
        private readonly GestionDeRecetaContext gestionDeRecetaContext;
        private readonly RecetaIngredienteContext recetaIngredienteContext;

        public GestionarRecetasDA(GestionDeRecetaContext context)
        {
            this.gestionDeRecetaContext = context;
        }

        public async Task<bool> actualizarReceta(int id, Receta receta)
        {
            Receta recetaExistente = await gestionDeRecetaContext.Receta.FindAsync(id);

            if (recetaExistente == null)
                return false;

            recetaExistente.Nombre = receta.Nombre;
            recetaExistente.Descripcion = receta.Descripcion;
            recetaExistente.Instrucciones = receta.Instrucciones;
            recetaExistente.Tiempo = receta.Tiempo;
            recetaExistente.Categoria = receta.Categoria;
            recetaExistente.ImagenURL = receta.ImagenURL;

            await gestionDeRecetaContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> eliminarReceta(int id)
        {
            var receta = await gestionDeRecetaContext.Receta.FindAsync(id);

            if (receta == null)
                return false;

            gestionDeRecetaContext.Receta.Remove(receta);
            await gestionDeRecetaContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> obtenerReceta(int id)
        {
            var receta = await gestionDeRecetaContext.Receta.FindAsync(id);

            return receta != null;
        }

        public async Task<List<Receta>> obtenerRecetas()
        {
            return await gestionDeRecetaContext.Receta.ToListAsync();
        }

        public async Task<bool> registrarReceta(Receta receta)
        {
            try
            {
                gestionDeRecetaContext.Receta.Add(receta);

                await gestionDeRecetaContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AregarIngredienteReceta(int recetaId, RecetaIngrediente dto)
        {
            var receta = await gestionDeRecetaContext.Receta.FindAsync(recetaId);
            if (receta == null)
                return false;

            var recetaIngrediente = new RecetaIngrediente
            {
                RecetaId = recetaId,
                IngredienteId = dto.IngredienteId,
                Cantidad = dto.Cantidad
            };

            gestionDeRecetaContext.RecetaIngrediente.Add(recetaIngrediente);
            await gestionDeRecetaContext.SaveChangesAsync();

            return true;
        }

        async Task<bool> IGestionarRecetasDA.ActualizarIngredienteReceta(int recetaId, int ingredienteId, RecetaIngrediente dto)
        {
            var relacionExistente = await gestionDeRecetaContext.RecetaIngrediente
                .FirstOrDefaultAsync(ri => ri.RecetaId == recetaId && ri.IngredienteId == ingredienteId);

            if(relacionExistente == null)
            {
                return false;
            }

            relacionExistente.Cantidad = dto.Cantidad;

            await gestionDeRecetaContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarIngredienteReceta(int recetaId, int ingredienteId)
        {
            var relacionExistente = await gestionDeRecetaContext.RecetaIngrediente
                .FirstOrDefaultAsync(ri => ri.RecetaId == recetaId && ri.IngredienteId == ingredienteId);

            if(relacionExistente == null)
            {
                return false;
            }

            gestionDeRecetaContext.RecetaIngrediente.Remove(relacionExistente);

            await gestionDeRecetaContext.SaveChangesAsync();

            return true;
        }
    }
}
