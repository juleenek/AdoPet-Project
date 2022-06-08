using AdoPet_Project.WPF.Enums;
using AdoPet_Project.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdoPet_Project.WPF.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy DogsPage.xaml
    /// </summary>
    public partial class DogsPage : Page
    {
        public List<Dog> DatabaseDogs { get; private set; }

        public DogsPage()
        {           
            InitializeComponent();
            Read();
        }
        /// <summary>
        /// Method that clears all data from Textboxes
        /// </summary>
        public void ClearData()
        {
            name_txt.Clear();
            age_txt.Clear();
            gender_txt.Clear();
            breed_txt.Clear();
        }
        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }
        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseDogs = context.Dogs.ToList();
                datagrid.ItemsSource = DatabaseDogs; 
               
            }
        }
        /// <summary>
        /// Create a Dog
        /// </summary>
        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                var name = name_txt.Text.ToLower();
                var age = age_txt.Text;
                var gender = gender_txt.Text.ToLower();
                var breed = breed_txt.Text.ToLower();

                if (name != null && age != null && gender != null && breed != null)
                {
                    DogBreed dogBreed;

                    try
                    {
                        dogBreed = context.DogBreeds.Single(x => x.BreedName == breed);
                    }
                    catch (Exception)
                    {
                        dogBreed = new Models.DogBreed() { BreedName = breed };
                    }

                    try
                    {
                        context.Dogs.Add(new Models.Dog()
                        {
                            Name = name,
                            Age = byte.Parse(age),
                            Gender = (Gender)Enum.Parse(typeof(Gender), gender),
                            BreedName = breed,
                            Breed = dogBreed
                        });
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("Please select a male or female gender.");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Please enter age in the correct format.");
                    }

                    context.SaveChanges();
                    Read();

                }
            }
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }
        public void Update()
        {
            using (DataContext context = new DataContext())
            {
                Dog selectedDog = datagrid.SelectedItem as Dog;

                var name = name_txt.Text.ToLower();
                var age = age_txt.Text;
                var gender = gender_txt.Text.ToLower();
                var breed = breed_txt.Text.ToLower();

                if (name != null && age != null && gender != null && breed != null)
                {
                    Dog dog = context.Dogs.Find(selectedDog.Id);

                    dog.Name = name;
                    dog.Age = byte.Parse(age);
                    dog.Gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    dog.Breed = new Models.DogBreed() { BreedName = breed };
                    dog.BreedName = breed;

                    context.SaveChanges();
                    Read();
                }

            }
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
        public void Delete()
        {
            using (DataContext context = new DataContext())
            {
                Dog selectedDog = datagrid.SelectedItem as Dog;

                if (selectedDog != null)
                {
                    Dog dog = context.Dogs.Single(x => x.Id == selectedDog.Id);
                    context.Remove(dog);
                    context.SaveChanges();
                    Read();
                }

            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }
    }
}
