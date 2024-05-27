using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace AmonikItog
{
        internal class ColorConverter : IValueConverter
        {
            public object Convert(object color, Type targetType, object parameter, CultureInfo culture)
            {
                if ((string)color == "red")
                    return new SolidColorBrush(Color.FromRgb(255, 71, 44));
                else if ((string)color == "green")
                    return new SolidColorBrush(Color.FromRgb(152, 213, 72));
                else
                    return new SolidColorBrush(Colors.White);
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }
    
}
