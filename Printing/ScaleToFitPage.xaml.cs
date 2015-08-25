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
using System.Windows.Printing;

namespace Printing
{
    public partial class ScaleToFitPage : UserControl
    {
        public ScaleToFitPage()
        {
            InitializeComponent();
        }

        Grid printPanel = new Grid();
        private void btPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += new EventHandler<PrintPageEventArgs>(doc_PrintPage);
            doc.BeginPrint += new EventHandler<BeginPrintEventArgs>(doc_BeginPrint);
            doc.EndPrint += new EventHandler<EndPrintEventArgs>(doc_EndPrint);
            doc.Print("pinguini");
        }

        void doc_EndPrint(object sender, EndPrintEventArgs e)
        {
            this.img.RenderTransform = null;
            printPanel.Children.Clear();
            this.LayoutRoot.Children.Add(img);
        }

        void doc_BeginPrint(object sender, BeginPrintEventArgs e)
        {
            this.LayoutRoot.Children.Remove(img);
            printPanel.Children.Add(img);
        }

        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            printPanel.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
            printPanel.Width = printPanel.DesiredSize.Width;
            printPanel.Height = printPanel.DesiredSize.Height;
           

            double factor = 1;
            if (printPanel.Width > printPanel.Height)
            {
                factor = e.PrintableArea.Width / printPanel.Width;
            }
            else
            {
                factor = e.PrintableArea.Height / printPanel.Height;
            }

            ScaleTransform scale = new ScaleTransform { ScaleX = factor, ScaleY = factor };
            img.RenderTransform = scale;
            e.PageVisual = printPanel;
        }
    }
}
