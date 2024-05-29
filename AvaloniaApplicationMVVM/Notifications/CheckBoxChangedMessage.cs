using CommunityToolkit.Mvvm.Messaging.Messages;

namespace AvaloniaApplicationMVVM.Notifications
{
    public class CheckBoxChangedMessage
    {
        public bool Value { get; }
        public CheckBoxChangedMessage(bool value)
        {
            Value = value;
        }
    }
}
