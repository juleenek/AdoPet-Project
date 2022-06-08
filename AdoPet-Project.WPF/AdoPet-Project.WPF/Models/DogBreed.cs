using System.ComponentModel.DataAnnotations;

namespace AdoPet_Project.WPF.Models
{
    public class DogBreed
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BreedName { get; set; }

    }
}