using System.Windows;

namespace MVVMMediatR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = ServiceProviderInitializer.ServiceProvider.GetService<MainWindowViewModel>();
            DataContext = new MainWindowViewModel();
            var secondWindow = new SecondWindow();
            secondWindow.Show();
        }
    }
}