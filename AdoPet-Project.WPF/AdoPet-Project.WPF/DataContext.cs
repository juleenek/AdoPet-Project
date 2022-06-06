using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AdoPet_Project.WPF.Models;

namespace AdoPet_Project.WPF
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = UserData.db");
        }

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<DogBreed> DogBreeds { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<CatBreed> CatBreeds { get; set; }
    }
}
