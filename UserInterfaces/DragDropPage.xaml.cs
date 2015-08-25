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

namespace UserInterfaces
{
    public partial class DragDropPage : UserControl
    {
        public DragDropPage()
        {
            InitializeComponent();
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            String[] dropFormatArray = e.Data.GetFormats();
            if (dropFormatArray.Contains(DataFormats.FileDrop))
            {
                object dropObjectArray = e.Data.GetData(DataFormats.FileDrop);
                FileInfo[] fileObj = dropObjectArray as FileInfo[];
                foreach (FileInfo fi in fileObj)
                {
                    try
                    {
                        listBox.Items.Add(fi);
                    }
                    catch (Exception ex)
                    {
                        
                        
                    }
                }
            }

        }
    }
}
