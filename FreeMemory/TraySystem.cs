using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace FreeMemory
{
    public partial class MainWindow : Window
    {
        private NotifyIcon notifyIcon = new NotifyIcon();
        private readonly ContextMenu Menu = new ContextMenu();

        private void SetTraySystem()
        {
            SetContextMenu();

            notifyIcon.Icon = Properties.Resources.icon;
            notifyIcon.Text = "FreeMemory";
            notifyIcon.ContextMenu = Menu;
            notifyIcon.Visible = true;
        }

        private void SetContextMenu()
        {
            MenuItem settingItem = new MenuItem("Setting");
            MenuItem exitItem = new MenuItem("Exit");

            settingItem.Click += SettingItem_Click;
            exitItem.Click += ExitItem_Click;

            Menu.MenuItems.Add(settingItem);
            Menu.MenuItems.Add(exitItem);
        }

        private void SettingItem_Click(object sender, EventArgs e)
        {
            new SettingWindow().Show();
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
