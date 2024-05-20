using Microsoft.Extensions.DependencyInjection;

namespace MVVMMediatR
{
    public class ServiceProviderInitializer
    {
        public static ServiceProvider ServiceProvider { get; }

        static ServiceProviderInitializer()
        {
            var services = new ServiceCollection();
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ServiceProviderInitializer).Assembly);
            });
            //services.AddMediatR(typeof(ServiceProviderInitializer).Assembly);
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<SecondWindowViewModel>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
