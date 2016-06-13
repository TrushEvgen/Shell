using System.Windows;

namespace Shell.App.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           // Navigation.Navigation.Service = MainFrame.NavigationService;

           // DataContext = new MainViewModel(new ViewModelsResolver());
        }
    }
}
