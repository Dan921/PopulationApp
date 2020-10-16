﻿using PopulationApp.Views;
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

namespace PopulationApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_People_Click(object sender, RoutedEventArgs e)
        {
            PeopleWindow peopleWindow = new PeopleWindow();
            peopleWindow.Show();
        }

        private void Button_Countries_Click(object sender, RoutedEventArgs e)
        {
            CountriesWindow countriesWindow = new CountriesWindow();
            countriesWindow.Show();
        }
    }
}
