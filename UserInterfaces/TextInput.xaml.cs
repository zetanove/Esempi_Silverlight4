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
    public partial class TextInput : UserControl
    {
        public TextInput()
        {
            InitializeComponent();
        }

        private void cboScrollBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScrollBarVisibility sbv = (ScrollBarVisibility)Enum.Parse(typeof(ScrollBarVisibility), cboScrollBar.SelectedValue.ToString(), false);
                    txtMultiline.HorizontalScrollBarVisibility = sbv;
                    txtMultiline.VerticalScrollBarVisibility = sbv;
            
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        public void Init()
        {
            cboScrollBar.Items.Clear();
            cboScrollBar.Items.Add(ScrollBarVisibility.Auto.ToString());
            cboScrollBar.Items.Add(ScrollBarVisibility.Disabled.ToString());
            cboScrollBar.Items.Add(ScrollBarVisibility.Hidden.ToString());
            cboScrollBar.Items.Add(ScrollBarVisibility.Visible.ToString());

            string str = "";
            for (int i = 1; i <= 15; i++)
                str += "linea " + i + Environment.NewLine;
            txtMultiline.Text = str;
        }

        private void btCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtMultiline.SelectedText);
        }

        private void btPaste_Click(object sender, RoutedEventArgs e)
        {
            int index=txtMultiline.SelectionStart;
            txtMultiline.Text.Insert(index, Clipboard.GetText());
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtReadOnly.Text = (sender as TextBox).Text;
        }
    }
}
