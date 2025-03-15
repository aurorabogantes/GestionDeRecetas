
using GestionDeRecetas.BC.Modelos;

namespace GestionDeRecetas.BW.Interfaces.BW
{
    public interface IGestionarRecetaIngredienteBW
    {
        Task<bool> registrarRecetaIngrediente(RecetaIngrediente recetaIngrediente);
        Task<bool> actualizarRecetaIngrediente(int IdReceta, int IdIngrediente, RecetaIngrediente recetaIngrediente);
        Task<bool> eliminarRecetaIngrediente(int IdReceta, int IdIngrediente);
    }
}
