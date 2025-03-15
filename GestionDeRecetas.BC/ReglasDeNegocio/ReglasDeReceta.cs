
using GestionDeRecetas.BC.Modelos;

namespace GestionDeRecetas.BC.ReglasDeNegocio
{
    public static class ReglasDeReceta
    {
        public static bool laRecetaEsValida(Receta receta)
        {
            return receta != null &&
                !string.IsNullOrEmpty(receta.Nombre) &&
                !string.IsNullOrEmpty(receta.Instrucciones) &&
                receta.Nombre.Length >= 3 && receta.Nombre.Length <= 255 &&
                receta.Descripcion.Length >= 10 && receta.Descripcion.Length <= 500 &&
                receta.Instrucciones.Length >= 50 &&
                receta.Id <= 0;
        }

        public static bool elIdEsValido(int id)
        {
            return id <= 0;
        }
    }
}
