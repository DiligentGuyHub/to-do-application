using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.WPF.State.Accounts;
using ToDo.WPF.State.Authenticators;
using ToDo.WPF.State.Navigators;
using ToDo.WPF.ViewModels;
using ToDo.WPF.ViewModels.Factories;

namespace ToDo.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IToDoViewModelFactory, ToDoViewModelFactory>();

                services.AddSingleton<AccountViewModel>();
                services.AddSingleton<TaskSummaryViewModel>();
                services.AddSingleton<SettingsViewModel>();
                services.AddSingleton<MessageViewModel>();
                services.AddSingleton<MainViewModel>();

                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();

                services.AddSingleton<HomeViewModel>(services => new HomeViewModel(
                    ExchangeRateListingViewModel.LoadExchangeIndexViewModel(
                        services.GetRequiredService<IExchangeRateService>()),
                        services.GetRequiredService<IAuthenticator>(),
                        services.GetRequiredService<TaskSummaryViewModel>()
                    ));

                services.AddSingleton<TodayViewModel>(services => new TodayViewModel(
                    services.GetRequiredService<ITaskService>(),
                    services.GetRequiredService<IAccountStore>(),
                    services.GetRequiredService<IAccountService>(),
                    services.GetRequiredService<TaskSummaryViewModel>(),
                    services.GetRequiredService<MessageViewModel>()
                    ));

                services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
                {
                    return () => services.GetRequiredService<HomeViewModel>();
                });

                services.AddSingleton<CreateViewModel<TodayViewModel>>(services =>
                {
                    return () => services.GetRequiredService<TodayViewModel>();
                });

                services.AddSingleton<CreateViewModel<SettingsViewModel>>(services =>
                {
                    return () => services.GetRequiredService<SettingsViewModel>();
                });

                services.AddSingleton<CreateViewModel<TaskSummaryViewModel>>(services =>
                {
                    return () => services.GetRequiredService<TaskSummaryViewModel>();
                });

                services.AddSingleton<CreateViewModel<AccountViewModel>>(services =>
                {
                    return () => new AccountViewModel(
                        services.GetRequiredService<IAccountStore>(),
                        services.GetRequiredService<IAccountService>(),
                        services.GetRequiredService<MessageViewModel>(),
                        services.GetRequiredService<MessageViewModel>());
                });

                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services =>
                {
                    return () => new RegisterViewModel(
                        services.GetRequiredService<IAuthenticator>(),
                        services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                        services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>()
                        );
                });

                services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
                {
                    return () => new LoginViewModel(
                        services.GetRequiredService<IAuthenticator>(),
                        services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                        services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>(),
                        services.GetRequiredService<MessageViewModel>());
                });
            });

            return host;
        }
    }
}
