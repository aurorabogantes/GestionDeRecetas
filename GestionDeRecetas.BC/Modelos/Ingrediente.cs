
namespace GestionDeRecetas.BC.Modelos
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }

        public List<RecetaIngrediente> RecetaIngredientes { get; set; }
    }
}
