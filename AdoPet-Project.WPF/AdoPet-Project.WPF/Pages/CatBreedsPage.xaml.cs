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
        public CatBreedsPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Method that clears all data from Textboxes
        /// </summary>
        public void ClearData()
        {
            breedname_txt.Clear();
            weight_txt.Clear();
            height_txt.Clear();
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearData_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }
    }
}
