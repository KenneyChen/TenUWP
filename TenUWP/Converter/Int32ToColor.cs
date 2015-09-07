using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace TenUWP
{
    public class Int32ToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //bebfc0
            return value.Equals(Int32.Parse(parameter.ToString())) ? new SolidColorBrush(Color.FromArgb(255, 0xbe, 0xbf, 0xc0)) :
                new SolidColorBrush(Color.FromArgb(255, 0xa6, 0xa7, 0xa9));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return new Nullable<bool>((bool)value);
        }
    }
}
