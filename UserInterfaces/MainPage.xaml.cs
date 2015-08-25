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
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void btFonts_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new Fonts());
        }

        private void btTextInput_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            TextInput ctrl = new UserInterfaces.TextInput();
            ctrl.Init();
            theContainer.Children.Add(ctrl);
        }

        private void btPassword_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new PasswordPage());
        }

        private void btAutocompleteBox_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new AutoComplete());
        }

        private void btButtons_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new Buttons());
        }

        private void btItemsControl_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new ItemsControlPage());
        }

        private void btDateControls_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new DatePages());
        }

        private void btRangeControls_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new RangePage());
        }

        private void btTabControls_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new TabControlPage());
        }

        private void btMessages_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new MessagesPage());
        }

        private void btFullscreen_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new FullScreenPage());
        }

        private void btDrag_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new DragDropPage());
        }
    }

    public class MyButton: ContentControl
    {
        
        
    }
}
