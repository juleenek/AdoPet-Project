﻿using AdoPet_Project.WPF.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdoPet_Project.WPF.Models
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte Age { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string BreedName { get; set; }
        [Required]
        public DogBreed Breed { get; set; }

    }
}