using AdoPet_Project.WPF.Enums;
using System.ComponentModel.DataAnnotations;

namespace AdoPet_Project.WPF.Models
{
    public class Cat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public CatBreed Breed { get; set; }
    }
}