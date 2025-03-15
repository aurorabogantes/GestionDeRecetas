
using GestionDeRecetas.BC.Modelos;

namespace GestionDeRecetas.BW.Interfaces.BW
{
    public interface IGestionarRecetasBW
    {
        Task<bool> registrarReceta(Receta receta);
        Task<bool> actualizarReceta(int id, Receta receta);
        Task<bool> eliminarReceta(int id);
        Task<List<Receta>> obtenerRecetas();
        Task<bool> obtenerReceta(int id);

        Task<bool> AregarIngredienteReceta(int recetaId, RecetaIngrediente dto);
        Task<bool> ActualizarIngredienteReceta(int recetaId, int ingredienteId, RecetaIngrediente dto);
        Task<bool> EliminarIngredienteReceta(int recetaId, int ingredienteId);
    }
}
