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

namespace AttachedProperties
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(bt2, 100.0);
            
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            bt1.SetValue(Canvas.LeftProperty, 100.0);
        }
    }
}
