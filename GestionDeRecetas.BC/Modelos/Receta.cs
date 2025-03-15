
namespace GestionDeRecetas.BC.Modelos
{
    public enum categoria
    {
        Desayuno,
        Almuerzo,
        Cena,
        Postre,
        Merienda
    }
    public class Receta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Instrucciones { get; set; }
        public int Tiempo { get; set; }
        public categoria Categoria { get; set; }
        public string ImagenURL { get; set; }
    }
}
