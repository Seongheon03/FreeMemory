using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FreeMemory.Converter
{
    public class DayOfWeekToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((DayOfWeek)value)
            {
                case DayOfWeek.Monday:
                    return "월요일";
                case DayOfWeek.Tuesday:
                    return "화요일";
                case DayOfWeek.Wednesday:
                    return "수요일";
                case DayOfWeek.Thursday:
                    return "목요일";
                case DayOfWeek.Friday:
                    return "금요일";
                case DayOfWeek.Saturday:
                    return "토요일";
                default:
                    return "일요일";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
