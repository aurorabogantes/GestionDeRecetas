
using System.Collections.Generic;
using System.Reflection.Emit;
using GestionDeRecetas.BC.Modelos;
using Microsoft.EntityFrameworkCore;

namespace GestionDeRecetas.DA.Config
{
    public class GestionDeIngredienteContext : DbContext
    {
        public GestionDeIngredienteContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Ingrediente> Ingrediente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
