using MediatR;

namespace MVVMMediatR
{
    public class CheckBoxStateChangedNotification : INotification
    {
        public bool NewState { get; }

        public CheckBoxStateChangedNotification(bool newState)
        {
            NewState = newState;
        }
    }
}
