﻿using System;
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
    /// Logika interakcji dla klasy Cats.xaml
    /// </summary>
    public partial class Cats : Page
    {
        public Cats()
        {
            InitializeComponent();
        }
        public void ClearData()
        {
            name_txt.Clear();
            age_txt.Clear();
            gender_txt.Clear();
            breed_txt.Clear();
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
