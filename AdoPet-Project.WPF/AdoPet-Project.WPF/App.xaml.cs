using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AdoPet_Project.WPF.DataAccess;
using AdoPet_Project.WPF.Pages;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AdoPet_Project.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e) // Everytime when app start up
        {
            DatabaseFacade facade = new DatabaseFacade(new DataContext());
            facade.EnsureCreated(); // Ensure that DB is created if it doesn't exist 
        }
    }
}
