using MediatR;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMMediatR
{
    public class SecondWindowViewModel : INotifyPropertyChanged, INotificationHandler<CheckBoxStateChangedNotification>
    {
        private bool _checkBoxState;

        public bool CheckBoxState
        {
            get { return _checkBoxState; }
            set
            {
                if (_checkBoxState != value)
                {
                    _checkBoxState = value;
                    OnPropertyChanged("CheckBoxState");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Task Handle(CheckBoxStateChangedNotification notification, CancellationToken cancellationToken)
        {
            CheckBoxState = notification.NewState;
            return Task.CompletedTask;
        }

        /*        protected virtual void OnPropertyChanged(string propertyName)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }*/

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
