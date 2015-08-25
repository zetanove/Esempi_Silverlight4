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
using System.IO;

namespace AdvancedSilverlight
{
    public partial class FileIOPage : UserControl
    {
        public FileIOPage()
        {
            InitializeComponent();
        }

        private void btOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "file di testo (*.txt, *.xml)|*.txt;*.xml";
            bool? userAccepts = openFileDialog.ShowDialog();
            if (userAccepts == true)
            {
                Stream fs = openFileDialog.File.OpenRead();
                using (StreamReader sr = new StreamReader(fs))
                {
                    textBox1.Text = sr.ReadToEnd();
                }
                fs.Close();
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Nessun contenuto da salvare");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "File di testo (*.txt)|*.txt";
            bool? userAccepts = saveFileDialog.ShowDialog();
            if (userAccepts == true)
            {
                Stream fs = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(textBox1.Text);
                sw.Flush();
                sw.Close();
            }
        }

    }
}
