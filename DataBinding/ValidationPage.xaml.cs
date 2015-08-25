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

namespace DataBinding
{
    public partial class ValidationPage : UserControl
    {
        Persona m_persona;
        public ValidationPage()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            m_persona=new Persona();
            m_persona.DataNascita = DateTime.Today.AddYears(-50);
            LayoutRoot.DataContext = m_persona;
        }

        private void LayoutRoot_BindingValidationError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                if(e.OriginalSource is TextBox)
                    (e.OriginalSource as TextBox).Background = new SolidColorBrush(Colors.Red);
            }
            else if (e.Action == ValidationErrorEventAction.Removed)
            {
                if (e.OriginalSource is TextBox)
                    (e.OriginalSource as TextBox).Background = new SolidColorBrush(Colors.White);
            }
        }
    }
}
