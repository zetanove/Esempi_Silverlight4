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

namespace LayoutContainers
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btCanvas_Click(object sender, RoutedEventArgs e)
        {
            CanvasPage canvas = new CanvasPage();
            theContainer.Children.Clear();
            theContainer.Children.Add( canvas);
        }

        private void btStackPanel_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new StackPanelPage());
        }

        private void btGrid_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new GridPage());
        }

        private void btWrapPanel_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new WrapPanelPage());
        }

        private void btGridLogin_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new GridLogin());
        }

        private void btDockPanel_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new DockPanelPage());
        }

        private void btRadialPanel_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new RadialPanelPage());
        }

    }
}
