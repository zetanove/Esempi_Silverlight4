﻿using System;
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

namespace DataBinding
{
    public partial class FormattingConversionPage : UserControl
    {
        public FormattingConversionPage()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            Persona p = this.Resources["persona"] as Persona;
            p.DataNascita = new DateTime(1975, 4, 18);
        }

        private void btChangeData_Click(object sender, RoutedEventArgs e)
        {
            Persona p = this.Resources["persona"] as Persona;
            p.DataNascita = new DateTime(2000, 4, 18);
        }
    }
}
