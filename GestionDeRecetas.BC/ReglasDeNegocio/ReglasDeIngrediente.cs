
using GestionDeRecetas.BC.Modelos;

namespace GestionDeRecetas.BC.ReglasDeNegocio
{
    public class ReglasDeIngrediente
    {
        public static bool elIngredienteEsValido(Ingrediente ingrediente)
        {
            return ingrediente != null &&
                !string.IsNullOrEmpty(ingrediente.Nombre) &&
                ingrediente.Nombre.Length >= 3 && ingrediente.Nombre.Length <= 255 &&
                ingrediente.Cantidad <= 0 &&
                ingrediente.Costo <= 0 &&
                ingrediente.Id <= 0;
        }

        public static bool elIdEsValido(int id)
        {
            return id <= 0;
        }
    }
}
