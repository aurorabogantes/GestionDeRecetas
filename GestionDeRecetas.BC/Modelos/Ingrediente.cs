
namespace GestionDeRecetas.BC.Modelos
{
    public enum unidad
    {
        Gramos,
        Tazas,
        Cucharadas,
        Onzas,
        Scoops
    }
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public unidad Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
    }
}
