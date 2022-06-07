using AdoPet_Project.WPF.DataAccess;
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
    /// Interaction logic for the CatBreedsPage.xaml class
    /// </summary>
    public partial class CatBreedsPage : Page
    {
        public List<CatBreed> DatabaseCatBreeds { get; private set; }

        public CatBreedsPage()
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
                DatabaseCatBreeds = context.CatBreeds.ToList();
                datagrid.ItemsSource = DatabaseCatBreeds;
            }
        }
        /// <summary>
        /// Create a Breed of Cat
        /// </summary>
        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                var breedName = breedname_txt.Text;

                if (breedName != null)
                {
                    context.CatBreeds.Add(new Models.CatBreed()
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
                CatBreed selectedCatBreed = datagrid.SelectedItem as CatBreed;

                var breedName = breedname_txt.Text;

                if (breedName != null)
                {
                    CatBreed catBreed = context.CatBreeds.Find(selectedCatBreed.Id);
                    catBreed.BreedName = breedName;                 

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
                CatBreed selectedCatBreed = datagrid.SelectedItem as CatBreed;

                if (selectedCatBreed != null)
                {
                    CatBreed catBreed = context.CatBreeds.Single(x => x.Id == selectedCatBreed.Id);
                    context.Remove(catBreed);
                    try
                    {
                        context.SaveChanges();
                        Read();
                    }
                    catch (DbUpdateException)
                    {
                        MessageBox.Show("You cannot delete a breed if there is a cat that owns it. Please remove the animal first, then breed.");
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
