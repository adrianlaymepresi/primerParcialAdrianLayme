using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;

namespace PrimerParcial.Data
{
    public class RecetasDBContext : DbContext
    {
        // Constructor que acepta DbContextOptions para la configuración
        public RecetasDBContext(DbContextOptions<RecetasDBContext> options)
            : base(options)
        {
        }

        // DbSets (Colecciones) que mapean a las tablas de la base de datos

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Opcional: Configuración de la relación uno a muchos
        // Esto a menudo se puede omitir si las convenciones de EF Core se cumplen,
        // pero es buena práctica para claridad, especialmente en relaciones complejas.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .IsRequired();

            // Recipe
            modelBuilder.Entity<Recipe>()
                .Property(r => r.Title)
                .HasMaxLength(100) 
                .IsRequired();

            modelBuilder.Entity<Recipe>()
                .Property(r => r.Description)
                .IsRequired();

            modelBuilder.Entity<Recipe>()
                .Property(r => r.PreparationTimeMinutes)
                .IsRequired();

            modelBuilder.Entity<Recipe>()
                .Property(r => r.Servings)
                .IsRequired();

            modelBuilder.Entity<Recipe>()
                .Property(r => r.Instructions)
                .IsRequired();

            modelBuilder.Entity<Recipe>()
                .Property(r => r.DateCreated)
                .IsRequired();

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category)  
                .WithMany(c => c.Recipes)  
                .HasForeignKey(r => r.CategoryId) 
                .OnDelete(DeleteBehavior.Cascade); 

            // Ingredient
            modelBuilder.Entity<Ingredient>()
                .Property(i => i.Name)
                .IsRequired();

            modelBuilder.Entity<Ingredient>()
                .Property(i => i.Quantity)
                .IsRequired();

            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.Recipe) 
                .WithMany(r => r.Ingredients) 
                .HasForeignKey(i => i.RecipeId) 
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
