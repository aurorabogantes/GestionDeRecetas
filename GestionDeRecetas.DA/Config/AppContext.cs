
using GestionDeRecetas.BC.Modelos;
using Microsoft.EntityFrameworkCore;

namespace GestionDeRecetas.DA.Config
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Receta> Receta { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<RecetaIngrediente> RecetaIngrediente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
