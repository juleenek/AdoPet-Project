using AdoPet_Project.WPF.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for the DogBreedsPage.xaml class
    /// </summary>
    public partial class DogBreedsPage : Page
    {
        public List<DogBreed> DatabaseDogBreeds { get; private set; }

        public DogBreedsPage()
        {
            InitializeComponent();
            Read();
        }
        /// <summary>
        /// Method that clears all data from Textboxes
        /// </summary>
        public void ClearData()
        {
            breedname_txt.Clear();
        }
        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }
        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseDogBreeds = context.DogBreeds.ToList();
                datagrid.ItemsSource = DatabaseDogBreeds;
            }
        }
        /// <summary>
        /// Create a Breed of Dog
        /// </summary>
        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                var breedName = breedname_txt.Text;

                if (breedName != null)
                {
                    context.DogBreeds.Add(new Models.DogBreed()
                    {
                        BreedName = breedName,
                    });
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
                DogBreed selectedDogBreed = datagrid.SelectedItem as DogBreed;

                var breedName = breedname_txt.Text;

                if (breedName != null)
                {
                    DogBreed dogBreed = context.DogBreeds.Find(selectedDogBreed.Id);
                    dogBreed.BreedName = breedName;

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
                DogBreed selectedDogBreed = datagrid.SelectedItem as DogBreed;

                if (selectedDogBreed != null)
                { 
                    DogBreed dogBreed = context.DogBreeds.Single(x => x.Id == selectedDogBreed.Id);
                    context.Remove(dogBreed);
                    try
                    {
                        context.SaveChanges();
                        Read();
                    }
                    catch (DbUpdateException)
                    {
                        MessageBox.Show("You cannot delete a breed if there is a dog that owns it. Please remove the animal first, then breed.");
                    }                   
                }

            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }
    }
}
