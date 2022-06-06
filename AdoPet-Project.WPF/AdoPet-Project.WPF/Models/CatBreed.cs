using System.ComponentModel.DataAnnotations;

namespace AdoPet_Project.WPF.Models
{
    public class CatBreed
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BreedName { get; set; }
        [Required]
        public decimal Height { get; set; }
        [Required]
        public decimal Weight { get; set; }
    }
}