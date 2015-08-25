using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UserInterfaces
{
    public partial class AutoComplete : UserControl
    {
        public AutoComplete()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> countries = new List<string>();
            countries.Add("France");
            countries.Add("Germany");
            countries.Add("Ireland");
            countries.Add("Israel");
            countries.Add("Italy");
            countries.Add("Spain");
            autoCompleteBox.ItemsSource = countries;

            autoCompleteBox.TextFilter= FilterEndsWith;
            
        }

        public bool FilterEndsWith(string text, string item)
        {
            return item.EndsWith(text);
        }


    }
}
