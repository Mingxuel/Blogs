using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Color = System.Windows.Media.Color;

namespace MyDream
{
    class IntToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var color_yellow = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFC000");
			var color_green = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#00B050");
			if (value is int intValue)
			{
				return intValue >= 50 ? new SolidColorBrush(color_yellow) : new SolidColorBrush(color_green);
			}

			return new SolidColorBrush(color_green);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException("不支持从颜色转换回数值");
		}
	}
}
