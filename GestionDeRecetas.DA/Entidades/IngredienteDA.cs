
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeRecetas.DA.Entidades
{
    [Table("Ingrediente")]
    public class IngredienteDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public enum unidad
        {
            Gramos,
            Tazas,
            Cucharadas,
            Onzas,
            Scoops
        }
        [Required]
        public unidad Unidad { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        public decimal Costo { get; set; }

    }
}
