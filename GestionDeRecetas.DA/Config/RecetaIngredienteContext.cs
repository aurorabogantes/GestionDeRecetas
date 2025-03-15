
using GestionDeRecetas.BC.Modelos;
using GestionDeRecetas.DA.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GestionDeRecetas.DA.Config
{
    public class RecetaIngredienteContext : DbContext
    {
        public RecetaIngredienteContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RecetaIngredienteDA> RecetaIngrediente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
