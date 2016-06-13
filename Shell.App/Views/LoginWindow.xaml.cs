using Shell.App.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Shell.App.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as LoginViewModel).Password = (sender as PasswordBox).SecurePassword;
        }
    }
}
