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
    public partial class DatePages : UserControl
    {
        public DatePages()
        {
            InitializeComponent();
        }

        private void cboDisplayMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboDisplayMode!=null && cboDisplayMode.SelectedItem!=null)
            {
                ComboBoxItem item=cboDisplayMode.SelectedItem as ComboBoxItem;
                calendar1.DisplayMode = (CalendarMode) Enum.Parse(typeof(CalendarMode), item.Content.ToString(), true);
            }
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            calendar1.BlackoutDates.Add(new CalendarDateRange(new DateTime(2010, 8, 1), new DateTime(2010, 8, 31)));
            calendar1.BlackoutDates.Add(new CalendarDateRange(new DateTime(2010, 12, 25)));

            calendar1.BlackoutDates.AddDatesInPast();

        }
    }
}
