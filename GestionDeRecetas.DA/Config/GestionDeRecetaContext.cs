
using GestionDeRecetas.BC.Modelos;
using GestionDeRecetas.DA.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GestionDeRecetas.DA.Config
{
    public class GestionDeRecetaContext : DbContext
    {
        public GestionDeRecetaContext(DbContextOptions<GestionDeRecetaContext> options) : base(options)
        {
        }

        public DbSet<Receta> Receta { get; set; }
        public DbSet<RecetaIngrediente> RecetaIngrediente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
