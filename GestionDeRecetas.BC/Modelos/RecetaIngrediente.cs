
namespace GestionDeRecetas.BC.Modelos
{
    public class RecetaIngrediente
    {
        public int RecetaId { get; set; }
        public Receta Receta { get; set; }

        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; }

        public decimal Cantidad { get; set; }
    }
}
