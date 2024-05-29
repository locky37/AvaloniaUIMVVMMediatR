using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaApplicationMVVM.Notifications;
using AvaloniaApplicationMVVM.ViewModels;
using AvaloniaApplicationMVVM.Views;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace AvaloniaApplicationMVVM;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

/*        var services = new ServiceCollection();

        // Register MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Register ViewModels
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<SecondViewModel>();
        services.AddSingleton<INotificationHandler<CheckBoxToggledNotification>>(serviceProvider => serviceProvider.GetRequiredService<MainViewModel>());
        services.AddSingleton<INotificationHandler<CheckBoxToggledNotification>>(serviceProvider => serviceProvider.GetRequiredService<SecondViewModel>());

        var serviceProvider = services.BuildServiceProvider();*/

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            /*            desktop.MainWindow = new MainWindow
                        {
                            //DataContext = new MainViewModel()
                            DataContext = serviceProvider.GetRequiredService<MainViewModel>()
                        };

                        var secondView = new SecondView
                        {
                            DataContext = serviceProvider.GetRequiredService<SecondViewModel>()
                            //DataContext = new SecondViewModel()
                        };

                        secondView.Show();*/

            var mainWindow = new MainView
            {
                DataContext = new MainViewModel()
            };

            var secondWindow = new SecondView
            {
                DataContext = new SecondViewModel()
            };

            desktop.MainWindow = mainWindow;

            // Show the main window
            mainWindow.Show();

            // Show the second window
            secondWindow.Show();


        }
/*        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }*/

        base.OnFrameworkInitializationCompleted();
    }
}
