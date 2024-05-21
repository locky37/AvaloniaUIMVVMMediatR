using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplicationMVVM.ViewModels
{
    public partial class MyCheckBoxControlViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool isChecked;
    }
}
