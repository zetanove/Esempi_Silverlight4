using System.Windows;
using System.Windows.Controls;

namespace DataBinding
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btDataBinding1_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new SimpleDataBindingPage());
        }

        private void btObjectDataBinding_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new DataContextPage());
        }

        private void btcodeBehindDataBinding_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new CodeDataBindingPage());
        }

        private void btCollectionBinding_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new CollectionBindingPage());
        }

        private void btFormatConversion_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new FormattingConversionPage());
        }

        private void btValidation_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new ValidationPage());
        }

        private void btDataForms_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new DataFormsPage());
        }

        private void btLabels_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new LabelsPage());
        }

        private void btDataGrid_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new DataGridPage());
        }

        private void btTree_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new TreeViewPage1());
        }

        private void btTreeDataBound_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new DataboundTreeView());
        }

        private void btAspnetWebService_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new WebServicesPage());
        }
    }
}
