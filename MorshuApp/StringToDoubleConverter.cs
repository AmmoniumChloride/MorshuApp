using System;
using System.Globalization;
using System.Windows.Data;

namespace MorshuApp
{
    class StringToDoubleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value?.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			
			var str = value.ToString();
			if (string.IsNullOrEmpty(str)) return 0;
			bool success = Double.TryParse(str, out double parsed);
			if (success) return parsed;
			return 0;
		}
	}
}
