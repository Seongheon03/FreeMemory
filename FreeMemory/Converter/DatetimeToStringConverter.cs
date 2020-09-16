using System;
using System.Globalization;
using System.Windows.Data;

namespace FreeMemory.Converter
{
    public class DatetimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime selectedTime = (DateTime)value;

            string str = "";

            switch (selectedTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    str = selectedTime.ToString("MM월 dd일 (월)");
                    break;
                case DayOfWeek.Tuesday:
                    str = selectedTime.ToString("MM월 dd일 (화)");
                    break;
                case DayOfWeek.Wednesday:
                    str = selectedTime.ToString("MM월 dd일 (수)");
                    break;
                case DayOfWeek.Thursday:
                    str = selectedTime.ToString("MM월 dd일 (목)");
                    break;
                case DayOfWeek.Friday:
                    str = selectedTime.ToString("MM월 dd일 (금)");
                    break;
                case DayOfWeek.Saturday:
                    str = selectedTime.ToString("MM월 dd일 (토)");
                    break;
                case DayOfWeek.Sunday:
                    str = selectedTime.ToString("MM월 dd일 (일)");
                    break;
            }

            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
