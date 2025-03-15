
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeRecetas.DA.Entidades
{
    [Table("RecetaIngrediente")]
    public class RecetaIngredienteDA
    {
        [Key, Column(Order = 0)]
        public int IdReceta { get; set; }

        [Key, Column(Order = 1)]
        public int IdIngrediente { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Cantidad { get; set; }

        [ForeignKey("IdReceta")]
        public virtual RecetaDA Receta { get; set; }

        [ForeignKey("IdIngrediente")]
        public virtual IngredienteDA Ingrediente { get; set; }
    }
}
