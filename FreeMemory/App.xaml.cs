using FreeMemory.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FreeMemory
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ServerUrl = "http://10.80.161.127:8080";
        //public static string ServerUrl = "http://192.168.43.64:8080";
        public static Network network = new Network();
        public static ScheduleViewModel ScheduleViewModel = new ScheduleViewModel();
    }
}
