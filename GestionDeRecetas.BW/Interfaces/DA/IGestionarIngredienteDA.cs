using GestionDeRecetas.BC.Modelos;

namespace GestionDeRecetas.BW.Interfaces.DA
{
    public interface IGestionarIngredienteDA
    {
        Task<List<Ingrediente>> obtenerIngredientes();
        Task<bool> obtenerIngrediente(int id);
        Task<bool> registrarIngrediente(Ingrediente ingrediente);
        Task<bool> actualizarIngrediente(int id, Ingrediente ingrediente);
        Task<bool> eliminarIngrediente(int id);
    }
}
