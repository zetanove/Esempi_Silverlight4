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

namespace UserInterfaces
{
    public partial class ItemsControlPage : UserControl
    {
        public ItemsControlPage()
        {
            InitializeComponent();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox1.SelectedItem is StackPanel)
            {
                StackPanel sp=listBox1.SelectedItem as StackPanel;
                textBlock1.Text= (sp.Children[1] as TextBlock).Text;
            }
        }

        
    }
}
