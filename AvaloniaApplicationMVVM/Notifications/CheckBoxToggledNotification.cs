using MediatR;

namespace AvaloniaApplicationMVVM.Notifications
{
    public class CheckBoxToggledNotification : INotification
    {
        public bool IsChecked { get; set; }

        public CheckBoxToggledNotification(bool isChecked)
        {
            IsChecked = isChecked;
        }
    }
}
