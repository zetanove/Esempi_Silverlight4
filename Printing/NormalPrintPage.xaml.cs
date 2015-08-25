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
using BookCommonLib;
using System.Windows.Printing;

namespace Printing
{
    public partial class NormalPrintPage : UserControl
    {
        public NormalPrintPage()
        {
            InitializeComponent();
        }

        private void btPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new EventHandler<PrintPageEventArgs>(printDocument_PrintPage);
            printDocument.EndPrint += new EventHandler<EndPrintEventArgs>(printDocument_EndPrint);
            printDocument.Print("print job");
        }

        void printDocument_EndPrint(object sender, EndPrintEventArgs e)
        {
            MessageBox.Show("Stampa completata");
        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.PageVisual = this.panelToPrint;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = Rubrica.Contatti;
        }
    }
}
