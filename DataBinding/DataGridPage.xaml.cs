using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DataBinding
{
    public partial class DataGridPage : UserControl
    {
        public DataGridPage()
        {
            InitializeComponent();
        }

        private void dataGrid2_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Eta")
            {
                e.Cancel=true;
            }
            if (e.PropertyType == typeof(DateTime))
            {
                DataGridBoundColumn col = e.Column as DataGridBoundColumn;
                if (col != null && col.Binding != null)
                {
                    col.Binding.StringFormat = "{0:dd/MM/yyyy}";
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = Rubrica.Contatti;
            dataGrid2.ItemsSource = Rubrica.Contatti;
            dataGrid3.ItemsSource = Rubrica.Contatti;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btColCognome_Click(object sender, RoutedEventArgs e)
        {
            Persona p = (sender as Button).DataContext as Persona;
            if (p != null)
            {
                MessageBox.Show("Hai cliccato su " + p.Cognome, "Hello", MessageBoxButton.OK);
            }
        }
    }
}
