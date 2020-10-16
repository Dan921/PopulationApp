using PopulationApp.Models;
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
using System.Windows.Shapes;

namespace PopulationApp.Views
{
    /// <summary>
    /// Логика взаимодействия для CountriesWindow.xaml
    /// </summary>
    public partial class CountriesWindow : Window
    {
        private PopulationContext populationContext = new PopulationContext();

        public CountriesWindow()
        {
            InitializeComponent();

            DataGridCountries.ItemsSource = populationContext.GetCountries();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            CountryWindow countryWindow = new CountryWindow();
            countryWindow.Owner = this;
            countryWindow.Show();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCountries.SelectedItems.Count > 0)
            {
                Country country = (Country)DataGridCountries.SelectedItems[0];
                CountryWindow countryWindow = new CountryWindow(country);
                countryWindow.Owner = this;
                countryWindow.Show();
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCountries.SelectedItems.Count > 0)
            {
                Country country = (Country)DataGridCountries.SelectedItems[0];
                populationContext.DeleteCountry(country.CountryId);

                Update();
            }
        }

        public void Update()
        {
            DataGridCountries.ItemsSource = populationContext.GetCountries();
            DataGridCountries.Items.Refresh();
        }
    }
}
