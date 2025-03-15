
namespace GestionDeRecetas.BC.Modelos
{
    public class Receta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Instrucciones { get; set; }
        public int Tiempo { get; set; } 
        public string Categoria { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Foto { get; set; }

        public List<RecetaIngrediente> RecetaIngredientes { get; set; }
    }
}
