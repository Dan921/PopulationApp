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
    /// Логика взаимодействия для PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        Person _person = new Person();

        private PopulationContext populationContext = new PopulationContext();

        public PersonWindow()
        {
            InitializeComponent();

            ComboBoxIdCountry.ItemsSource = populationContext.GetCountryIds();
            ComboBoxIdCountry.SelectedIndex = 0;
        }

        public PersonWindow(Person person)
        {
            InitializeComponent();

            ComboBoxIdCountry.ItemsSource = populationContext.GetCountryIds();
            ComboBoxIdCountry.SelectedIndex = 0;

            TextBoxFirstName.Text = person.FirstName;
            TextBoxLastName.Text = person.LastName;
            TextBoxAge.Text = person.Age.ToString();
            TextBoxGender.Text = person.FirstName;
            ComboBoxIdCountry.SelectedItem = person.CountryId;

            _person = person;
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(TextBoxFirstName.Text))
            {
                _person.FirstName = TextBoxFirstName.Text;
            } else
            {
                MessageBox.Show("Обязательно укажите имя");
            }

            if (!string.IsNullOrEmpty(TextBoxLastName.Text))
            {
                _person.FirstName = TextBoxLastName.Text;
            } else
            {
                MessageBox.Show("Обязательно укажите фамилию");
            }

            try
            {
                _person.Age = int.Parse(TextBoxAge.Text);
            } catch
            {
                MessageBox.Show("Поле 'Возраст' заполнено не корректно");
            }

            _person.Gender = TextBoxGender.Text;
            _person.CountryId = (int)ComboBoxIdCountry.SelectedItem;

            try
            {
                if(_person.PersonId == null)
                    populationContext.AddPerson(_person);
                if(_person.PersonId != null)
                    populationContext.EditPerson(_person);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

            ComboBoxIdCountry.Items.Refresh();
            this.Close();
        }
    }
}
