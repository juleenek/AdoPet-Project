using AdoPet_Project.WPF.DataAccess;
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
    }
}
