using AvaloniaApplicationMVVM.Notifications;
using CommunityToolkit.Mvvm.ComponentModel;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaApplicationMVVM.ViewModels;

public partial class MainViewModel : ObservableObject, INotificationHandler<CheckBoxToggledNotification>
{
    [ObservableProperty]
    private bool isChecked;

    [ObservableProperty]
    private string title = "Main Window";

    private readonly IMediator _mediator;
    private bool _isUpdating;

    public MyCheckBoxControlViewModel CheckBoxControlViewModel { get; }

    public MainViewModel(IMediator mediator)
    {
        //_mediator = mediator;

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
        // Обновляем значение только если оно отличается
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
