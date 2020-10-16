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
    /// Логика взаимодействия для CountryWindow.xaml
    /// </summary>
    public partial class CountryWindow : Window
    {
        Country _country = new Country();

        private PopulationContext populationContext = new PopulationContext();

        public CountryWindow()
        {
            InitializeComponent();

            ComboBoxContinent.ItemsSource = new List<string> { "Africa", "North America", "South America", "Australia", "Antarctica", "Eurasia" };
            ComboBoxContinent.SelectedIndex = 0;
        }

        public CountryWindow(Country country)
        {
            InitializeComponent();

            ComboBoxContinent.ItemsSource = new List<string> { "Africa", "North America", "South America", "Australia", "Antarctica", "Eurasia" };
            ComboBoxContinent.SelectedIndex = 0;

            TextBoxName.Text = country.Name;
            TextBoxPopulation.Text = country.Population.ToString();
            TextBoxArea.Text = country.Area.ToString();
            TextBoxCapital.Text = country.Capital;
            ComboBoxContinent.SelectedItem = country.Continent;

            _country = country;
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCheck())
            {
                _country.Name = TextBoxName.Text;
                _country.Population = int.Parse(TextBoxPopulation.Text);
                _country.Area = int.Parse(TextBoxArea.Text);
                _country.Capital = TextBoxCapital.Text;
                _country.Continent = ComboBoxContinent.SelectedItem.ToString();

                try
                {
                    if (_country.CountryId == null)
                    populationContext.AddCountry(_country);
                if (_country.CountryId != null)
                    populationContext.EditCountry(_country);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }

                ((CountriesWindow)this.Owner).Update();
                this.Close();
            }
        }

        private bool ModelCheck()
        {
            if (string.IsNullOrEmpty(TextBoxName.Text))
            {
                MessageBox.Show("Обязательно укажите имя!");
                return false;
            }
            try
            {
                int.Parse(TextBoxPopulation.Text);
            }
            catch
            {
                MessageBox.Show("Некорректное значение населения!");
                return false;
            }
            try
            {
                int.Parse(TextBoxArea.Text);
            }
            catch
            {
                MessageBox.Show("Некорректное значение площади!");
                return false;
            }
            return true;
        }
    }
}
