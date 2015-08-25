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
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using BookCommonLib;

namespace Printing
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        


        private void btSimplePrinting_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new NormalPrintPage());
        }

        private void btResizePrinting_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new ResizePrint());
        }

        private void btScaleTofit_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new ScaleToFitPage());
        }

        
    }
}
