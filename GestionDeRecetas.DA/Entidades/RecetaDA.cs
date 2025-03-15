
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using GestionDeRecetas.BC.Modelos;

namespace GestionDeRecetas.DA.Entidades
{
    [Table("Receta")]
    public class RecetaDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public string Instrucciones { get; set; }

        [Required]
        public int Tiempo { get; set; }

        public enum categoria
        {
            Desayuno,
            Almuerzo,
            Cena,
            Postre,
            Merienda
        }
        [Required]
        public categoria Categoria { get; set; }

        public string ImagenURL { get; set; }

        public virtual ICollection<RecetaIngredienteDA> RecetaIngredientes { get; set; }
    }
}
