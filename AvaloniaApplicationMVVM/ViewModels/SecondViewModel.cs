using AvaloniaApplicationMVVM.Notifications;
using CommunityToolkit.Mvvm.ComponentModel;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace AvaloniaApplicationMVVM.ViewModels
{
    public partial class SecondViewModel : ObservableObject, INotificationHandler<CheckBoxToggledNotification>
    {
        [ObservableProperty]
        private bool isChecked;

        [ObservableProperty]
        private string title = "Second Window";

        private readonly IMediator _mediator;
        private bool _isUpdating;

        public MyCheckBoxControlViewModel CheckBoxControlViewModel { get; }
        public SecondViewModel(IMediator mediator)
        {
            _mediator = mediator;

            CheckBoxControlViewModel = new MyCheckBoxControlViewModel();
            CheckBoxControlViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(CheckBoxControlViewModel.IsChecked))
                {
                    OnCheckBoxControlViewModelIsCheckedChanged();
                }
            };
        }

        private void OnCheckBoxControlViewModelIsCheckedChanged()
        {
            if (_isUpdating) return;
            IsChecked = CheckBoxControlViewModel.IsChecked;
            _mediator.Publish(new CheckBoxToggledNotification(CheckBoxControlViewModel.IsChecked));
        }

        partial void OnIsCheckedChanged(bool value)
        {
            // Предотвращаем рекурсивный вызов
            if (_isUpdating) return;
            CheckBoxControlViewModel.IsChecked = value;
            _mediator.Publish(new CheckBoxToggledNotification(value));
        }

        public Task Handle(CheckBoxToggledNotification notification, CancellationToken cancellationToken)
        {
            // Вариант 1
            if (IsChecked != notification.IsChecked)
            {
                _isUpdating = true;
                IsChecked = notification.IsChecked;
                CheckBoxControlViewModel.IsChecked = notification.IsChecked;
                _isUpdating = false;
            }
            return Task.CompletedTask;
        }
    }
}
