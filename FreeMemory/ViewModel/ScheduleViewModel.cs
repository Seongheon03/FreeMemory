using FreeMemory.Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeMemory.ViewModel
{
    public class ScheduleViewModel : INotifyPropertyChanged
    {
        private string SCHEDULE_URL = "/schedule";
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Property
        private List<Schedule> AllSchedules = new List<Schedule>();

        private ObservableCollection<Schedule> _schedules = new ObservableCollection<Schedule>();
        public ObservableCollection<Schedule> Schedules
        {
            get => _schedules;
            set
            {
                _schedules = value;
                NotifyPropertyChanged(nameof(Schedules));
            }
        }

        private DateTime _selectedDate = DateTime.Now;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                NotifyPropertyChanged(nameof(SelectedDate));
            }
        }

        private string _selectedDay = DateTime.Now.Day.ToString();
        public string SelectedDay
        {
            get => _selectedDay;
            set
            {
                _selectedDay = value;
                NotifyPropertyChanged(nameof(SelectedDay));
            }
        }

        private DayOfWeek _selectedDayOfWeek = DateTime.Now.DayOfWeek;
        public DayOfWeek SelectedDayOfWeek
        {
            get => _selectedDayOfWeek;
            set
            {
                _selectedDayOfWeek = value;
                NotifyPropertyChanged(nameof(SelectedDate));
            }
        }
        #endregion

        #region Command
        public DelegateCommand PrevDayCommand { get; set; }
        public DelegateCommand TodayCommand { get; set; }
        public DelegateCommand NextDayCommand { get; set; }
        #endregion

        public ScheduleViewModel()
        {
            PrevDayCommand = new DelegateCommand(OnPrevDay);
            TodayCommand = new DelegateCommand(OnToday);
            NextDayCommand = new DelegateCommand(OnNextDay);
            LoadSchedule();
        }

        public async void LoadSchedule()
        {
            Schedules.Clear();

            var resp = await App.network.GetResponse<ScheduleResponse>(App.ServerUrl + SCHEDULE_URL, RestSharp.Method.GET);
            AllSchedules = resp.Data.schedules;

            if (AllSchedules != null && AllSchedules.Count != 0)
            {
                try
                {
                    Schedule schedule = new Schedule();

                    foreach (var item in AllSchedules)
                    {
                        if (item.StartTime <= SelectedDate && SelectedDate <= item.EndTime.AddDays(1))
                        {
                            Schedules.Add(item);
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }
            }
        }

        private void OnPrevDay()
        {
            SelectedDate = SelectedDate.AddDays(-1);
            SelectedDay = SelectedDate.Day.ToString();
            SelectedDayOfWeek = SelectedDate.DayOfWeek;
            LoadSchedule();
        }

        private void OnToday()
        {
            SelectedDate = DateTime.Now;
            SelectedDay = SelectedDate.Day.ToString();
            SelectedDayOfWeek = SelectedDate.DayOfWeek;
            LoadSchedule();
        }

        private void OnNextDay()
        {
            SelectedDate = SelectedDate.AddDays(1);
            SelectedDay = SelectedDate.Day.ToString();
            SelectedDayOfWeek = SelectedDate.DayOfWeek;
            LoadSchedule();
        }

    }
}
