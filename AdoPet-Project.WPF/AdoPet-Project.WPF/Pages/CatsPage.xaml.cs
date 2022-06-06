using AdoPet_Project.WPF.DataAccess;
using AdoPet_Project.WPF.Enums;
using AdoPet_Project.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
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
    /// Interaction logic for the Cats.xaml class
    /// </summary>
    public partial class Cats : Page
    {
        public List<Cat> DatabaseCats { get; private set; }

        public Cats()
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
                DatabaseCats = context.Cats.ToList();
                datagrid.ItemsSource = DatabaseCats;
            }
        }
        /// <summary>
        /// Create a Cat
        /// </summary>
        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                var name = name_txt.Text;
                var age = age_txt.Text;
                var gender = gender_txt.Text;
                var breed = breed_txt.Text;

                if (name != null && age != null && gender != null && breed != null)
                {
                    context.Cats.Add(new Models.Cat()
                    {
                        Name = name,
                        Age = byte.Parse(age),
                        Gender = (Gender)Enum.Parse(typeof(Gender), gender),
                        Breed = new Models.CatBreed() { BreedName = breed }
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
                Cat selectedCat = datagrid.SelectedItem as Cat;

                var name = name_txt.Text;
                var age = age_txt.Text;
                var gender = gender_txt.Text;
                var breed = breed_txt.Text;

                if (name != null && age != null && gender != null && breed != null)
                {
                    Cat cat = context.Cats.Find(selectedCat.Id);

                    cat.Name = name;
                    cat.Age = byte.Parse(age);
                    cat.Gender = (Gender)Enum.Parse(typeof(Gender), gender);
                    cat.Breed = new Models.CatBreed() { BreedName = breed };

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
                Cat selectedCat = datagrid.SelectedItem as Cat;

                if (selectedCat != null)
                {
                    Cat cat = context.Cats.Single(x => x.Id == selectedCat.Id);
                    context.Remove(cat);
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
