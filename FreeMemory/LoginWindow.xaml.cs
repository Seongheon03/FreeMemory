using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FreeMemory
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    /// 
    public partial class LoginWindow : Window
    {
        private const string LOGIN_URL = "/auth/login";

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            new RegisterWindow(this).Show();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            JObject jobj = new JObject();
            jobj["id"] = tbId.Text;
            jobj["pw"] = pbPwd.Password;

            var resp = await App.network.GetResponse<Nothing>(App.ServerUrl + LOGIN_URL, RestSharp.Method.POST, jobj.ToString());

            MessageBox.Show(resp.Message);

            if (resp.Status == 200)
            {
                new MainWindow().Show();
                this.Close();
            }
        }
    }
}
