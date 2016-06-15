using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Shell.App.Views
{
    public partial class MainWindow : Window
    {
        private NotifyIcon notifyIcon;

        public MainWindow()
        {
            InitializeComponent();

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            notifyIcon.Click += new EventHandler(NotifyIcon_Click);
        }

        void NotifyIcon_Click(object sender, EventArgs e)
        {
            var button = (e as MouseEventArgs).Button;
            if (button == MouseButtons.Left)
            {
                this.WindowState = WindowState.Normal;
            }
            else if (button == MouseButtons.Right)
            {
            
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon.BalloonTipTitle = "Minimize Sucessful";
                notifyIcon.BalloonTipText = "Minimized the app ";
                notifyIcon.ShowBalloonTip(400);
                notifyIcon.Visible = true;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                notifyIcon.Visible = false;
                this.ShowInTaskbar = true;
                this.Activate();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           // Navigation.Navigation.Service = MainFrame.NavigationService;

           // DataContext = new MainViewModel(new ViewModelsResolver());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            this.WindowState = System.Windows.WindowState.Minimized;
        }
    }
}
