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
    /// Логика взаимодействия для PeopleWindow.xaml
    /// </summary>
    public partial class PeopleWindow : Window
    {
        private PopulationContext populationContext = new PopulationContext();

        public PeopleWindow()
        {
            InitializeComponent();

            DataGridPeople.ItemsSource = populationContext.GetPeople();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            PersonWindow personWindow = new PersonWindow();
            personWindow.Show();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPeople.SelectedItems.Count > 0)
            {
                Person person = (Person)DataGridPeople.SelectedItems[0];
                PersonWindow personWindow = new PersonWindow(person);
                personWindow.Show();
            }
        }
    }
}
