using AvaloniaApplicationMVVM.Notifications;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaApplicationMVVM.ViewModels
{
    public partial class SecondViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string title = "Second Window";

        private bool isChecked;
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                if (SetProperty(ref isChecked, value))
                {
                    WeakReferenceMessenger.Default.Send(new CheckBoxChangedMessage(value), nameof(SecondViewModel));
                }
            }
        }

        public SecondViewModel()
        {
            WeakReferenceMessenger.Default.Register<CheckBoxChangedMessage>(this, (r, m) =>
            {
                IsChecked = m.Value;
            });
        }
    }
}
