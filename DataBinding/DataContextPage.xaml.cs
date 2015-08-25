using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataBinding
{
    public partial class DataContextPage : UserControl
    {
        public DataContextPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Persona p = new Persona() { Nome = "Antonio", Cognome = "Pelleriti", DataNascita = new DateTime(1975, 4, 18) };
            LayoutRoot.DataContext = p;
        }

    }
}
