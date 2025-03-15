
using GestionDeRecetas.BC.Modelos;

namespace GestionDeRecetas.BC.ReglasDeNegocio
{
    public class Reglas
    {
        public static bool cantidadNecesaria(RecetaIngrediente recetaIngrediente)
        {
            return recetaIngrediente.Cantidad > 0;
        }
    }
}
