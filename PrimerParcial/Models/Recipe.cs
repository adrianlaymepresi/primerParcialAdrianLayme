using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models
{
    public class Recipe
    {
        // Modelado del Recipe
        public int Id { get; set; }

        [Required] 
        [StringLength(100)] 
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int PreparationTimeMinutes { get; set; }

        [Required]
        public int Servings { get; set; }
        [Required] 
        public string Instructions { get; set; } 

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }


    }
}
