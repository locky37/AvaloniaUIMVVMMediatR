using System.Windows;

namespace MVVMMediatR
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            //DataContext = ServiceProviderInitializer.ServiceProvider.GetService<SecondWindowViewModel>();
            DataContext = new SecondWindowViewModel();
        }
    }
}
