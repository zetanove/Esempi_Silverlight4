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
using System.Windows.Data;

namespace DataBinding
{
    public partial class CodeDataBindingPage : UserControl
    {
        public CodeDataBindingPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Persona p = new Persona() { Nome = "Antonio", Cognome = "Pelleriti", DataNascita = new DateTime(1975, 4, 18) };
            LayoutRoot.DataContext = p;

            Binding binding = new Binding();
            binding.Path =new PropertyPath("Nome");
            binding.Mode = BindingMode.TwoWay;
            txtNome.SetBinding(TextBox.TextProperty, binding);

            binding = new Binding();
            binding.Path = new PropertyPath("Cognome");
            binding.Mode = BindingMode.TwoWay;
            txtCognome.SetBinding(TextBox.TextProperty, binding);

            binding = new Binding();
            binding.Path = new PropertyPath("DataNascita");
            binding.Mode = BindingMode.TwoWay;
            dp.SetBinding(DatePicker.SelectedDateProperty, binding);

            binding = new Binding();
            binding.Path = new PropertyPath("Eta");
            binding.Mode = BindingMode.TwoWay;
            txtEta.SetBinding(TextBlock.TextProperty, binding);
        }




        private void btCambiaNome_Click(object sender, RoutedEventArgs e)
        {
            Persona p = LayoutRoot.DataContext as Persona;
            p.Nome = "Nuovo nome";
            p.Cognome = "nuovocognome";
            p.DataNascita = new DateTime(1950, 1, 1);

        }
    }
}
