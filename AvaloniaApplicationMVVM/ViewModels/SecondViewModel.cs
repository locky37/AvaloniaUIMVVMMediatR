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


        public SecondViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        partial void OnIsCheckedChanged(bool value)
        {
            // Предотвращаем рекурсивный вызов
            if (_isUpdating) return;
            _mediator.Publish(new CheckBoxToggledNotification(value));
        }

        public Task Handle(CheckBoxToggledNotification notification, CancellationToken cancellationToken)
        {
            // Вариант 1
            if (IsChecked != notification.IsChecked)
            {
                _isUpdating = true;
                IsChecked = notification.IsChecked;
                _isUpdating = false;
            }
            return Task.CompletedTask;
        }
    }
}
