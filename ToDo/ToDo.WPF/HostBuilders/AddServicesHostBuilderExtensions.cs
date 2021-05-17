using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.API.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Services.AuthenticationServices;
using ToDo.Domain.Services;
using ToDo.EntityFramework.Services.Common;
using ToDo.EntityFramework.Services;
using Microsoft.AspNet.Identity;

namespace ToDo.WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IDataService<User>, AccountDataService>();
                services.AddSingleton<IAccountService, AccountDataService>();
                services.AddSingleton<IExchangeRateService, ExchangeRateService>();
                services.AddSingleton<ITaskService, TaskDataService>();
                services.AddSingleton<IPasswordHasher, PasswordHasher>();
            });

            return host;
        }
    }
}
