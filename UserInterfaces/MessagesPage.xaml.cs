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
using System.Windows.Controls.Primitives;

namespace UserInterfaces
{
    public partial class MessagesPage : UserControl
    {
        public MessagesPage()
        {
            InitializeComponent();
        }

        private void btMsgBox1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nessun titolo, un pulsante OK.");
        }

        private void btMsgBox2_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Continuare?", "Conferma", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                MessageBox.Show("Hai confermato");
            }
            else MessageBox.Show("Hai cliccato su " + result);
        }

        private void showPopup_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        Popup p = new Popup();
        private void showPopup2_Click(object sender, RoutedEventArgs e)
        {
            if (p.IsOpen == true)
                return;
            Border border = new Border();
            border.BorderBrush = new SolidColorBrush(Colors.White);
            border.BorderThickness = new Thickness(2.0);

            StackPanel panel1 = new StackPanel();

            Button button1 = new Button();
            button1.Content = "Close";
            button1.Margin = new Thickness(5.0);
            button1.Click += new RoutedEventHandler(button1_Click);
            TextBlock textblock1 = new TextBlock();
            textblock1.Text = "Premi il pulsante Close";
            textblock1.Margin = new Thickness(5.0);
            panel1.Children.Add(textblock1);
            panel1.Children.Add(button1);
            border.Child = panel1;

            p = new Popup();
            // Imposta la proprietà Child con il border che è il contenitore principale che contiene a sua volta uno stackpanel, un textblock ed un button.
            p.Child = border;
            //imposta la posizione del popup
            p.VerticalOffset = 100;
            p.HorizontalOffset = 50;

            // apre il popup
            p.IsOpen = true;

        }

        void button1_Click(object sender, RoutedEventArgs e)
        {
            p.IsOpen = false;
        }
    }
}
