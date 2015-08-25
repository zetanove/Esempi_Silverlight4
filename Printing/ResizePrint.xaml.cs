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
    public partial class ResizePrint : UserControl
    {
        Grid printPanel = new Grid();
        public ResizePrint()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = Rubrica.Contatti;
        }

        private void btPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.BeginPrint += new EventHandler<BeginPrintEventArgs>(doc_BeginPrint);
            doc.PrintPage += new EventHandler<PrintPageEventArgs>(doc_PrintPage);
            doc.EndPrint += new EventHandler<EndPrintEventArgs>(doc_EndPrint);
            doc.Print("resizeprint");
        }


        void doc_BeginPrint(object sender, BeginPrintEventArgs e)
        {
            this.Content = null;
            printPanel = new Grid();
            printPanel.Children.Add(LayoutRoot);
        }

        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            printPanel.Height = e.PrintableArea.Height;
            printPanel.Width = e.PrintableArea.Width;
            e.PageVisual = printPanel;
            e.HasMorePages = false;
        }

        void doc_EndPrint(object sender, EndPrintEventArgs e)
        {
            printPanel.Children.Remove(LayoutRoot);
            this.Content = LayoutRoot;
        }
    }
}
