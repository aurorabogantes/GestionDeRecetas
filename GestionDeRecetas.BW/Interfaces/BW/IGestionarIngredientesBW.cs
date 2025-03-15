
using GestionDeRecetas.BC.Modelos;

namespace GestionDeRecetas.BW.Interfaces.BW
{
    public interface IGestionarIngredientesBW
    {
        Task<List<Ingrediente>> obtenerIngredientes();
        Task<bool> obtenerIngrediente(int id);
        Task<bool> registrarIngrediente(Ingrediente ingrediente);
        Task<bool> actualizarIngrediente(int id, Ingrediente ingrediente);
        Task<bool> eliminarIngrediente(int id);
    }
}
