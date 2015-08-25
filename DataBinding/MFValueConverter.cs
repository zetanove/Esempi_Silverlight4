using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace DataBinding
{
    public class MFValueConverter: IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isMaschio = bool.Parse(value.ToString());
            if(parameter!=null && parameter.ToString()=="extended")
                return isMaschio ? "Maschile" : "Femminile";
    
            return isMaschio ? "M" : "F";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = value.ToString().ToUpper();
            if (parameter != null && parameter.ToString() == "extended")
            {
                if (text == "MASCHILE")
                    return true;
                else if (text == "FEMMINILE")
                    return false;
                else throw new Exception("I valori possibili sono Maschile e Femminile");
            }
            else
            {
                if (text == "M")
                    return true;
                else if (text == "F")
                    return false;
                else throw new Exception("I valori possibili sono M e F");
            }
        }
    }
}
