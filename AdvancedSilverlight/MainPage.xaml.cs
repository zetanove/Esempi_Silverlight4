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

namespace AdvancedSilverlight
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btMultithread_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new MultithreadPage());
        }

        private void btIsolatedStorage_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new IsolatedStoragePage());
        }

        private void btFile(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new FileIOPage());
        }
    }
}
