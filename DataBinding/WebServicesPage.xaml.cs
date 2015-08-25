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
    public partial class WebServicesPage : UserControl
    {
        public WebServicesPage()
        {
            InitializeComponent();
        }

        private void btGetProdotti_Click(object sender, RoutedEventArgs e)
        {
            ProdottiServiceReference.ProdottiServiceSoapClient client = new ProdottiServiceReference.ProdottiServiceSoapClient();
            client.GetProdottiCompleted += new EventHandler<ProdottiServiceReference.GetProdottiCompletedEventArgs>(client_GetProdottiCompleted);
            client.GetProdottiAsync();
        }

        void client_GetProdottiCompleted(object sender, ProdottiServiceReference.GetProdottiCompletedEventArgs e)
        {
            dataGrid.ItemsSource = e.Result;
        }
    }
}
