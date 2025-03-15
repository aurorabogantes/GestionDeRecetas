using GestionDeRecetas.BC.Modelos;

namespace GestionDeRecetas.BW.Interfaces.DA
{
    public interface IGestionarRecetasDA
    {
        Task<bool> registrarReceta(Receta receta);
        Task<bool> actualizarReceta(int id, Receta receta);
        Task<bool> eliminarReceta(int id);
        Task<List<Receta>> obtenerRecetas();
        Task<bool> obtenerReceta(int id);
    }
}
