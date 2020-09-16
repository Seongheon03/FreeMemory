using Newtonsoft.Json.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FreeMemory
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        private string SCHEDULE_URL = "/schedule";

        public SettingWindow()
        {
            InitializeComponent();
            Loaded += SettingWindow_Loaded;
        }

        private void SettingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = App.ScheduleViewModel;
            var desktopWorkingArea = SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }

        private async void btnAdd(object sender, RoutedEventArgs e)
        {
            if (calendar.SelectedDate == null)
            {
                MessageBox.Show("날짜를 선택해주세요");
                return;
            }

            else if (tbTitle.Text == "")
            {
                MessageBox.Show("일정 이름을 입력해주세요");
                return;
            }

            JObject jobj = new JObject();
            jobj["name"] = tbTitle.Text.ToString();
            jobj["startDate"] = calendar.SelectedDate;
            jobj["endDate"] = calendar.SelectedDate;
            jobj["target"] = cbGrade.SelectedIndex + 1;
            jobj["type"] = cbTarget.SelectedIndex + 1;

            var resp = await App.network.GetResponse<Nothing>(App.ServerUrl + SCHEDULE_URL, RestSharp.Method.POST, jobj.ToString());

            MessageBox.Show(resp.Message);
            App.ScheduleViewModel.LoadSchedule();

            tbTitle.Text = "";
        }

        private void cbTarget_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTarget.SelectedIndex == 1)
            {
                cbGrade.IsEnabled = false;
            }
            else
            {
                cbGrade.IsEnabled = true;
            }
        }
    }
}
