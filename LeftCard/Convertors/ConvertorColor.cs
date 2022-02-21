using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftCard.Convertors
{
    public class ConvertorColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ISolidColorBrush A = Brushes.Black;
            if ((int)value <= 30)
                A = Brushes.Yellow;
            else if ((int)value <= 65)
                A = Brushes.Orange;
            else if ((int)value <= 90)
                A = Brushes.Red;
            else if ((int)value > 90)
                A = Brushes.DarkRed;
            return A;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
