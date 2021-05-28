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
                services.AddScoped<IDataService<User>, AccountDataService>();
                services.AddScoped<IAccountService, AccountDataService>();
                services.AddScoped<ITaskService, TaskDataService>();
                services.AddScoped<IFileService, FileDataService>();
                services.AddScoped<IImageService, ImageDataService>();

                services.AddScoped<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IExchangeRateService, ExchangeRateService>();
                services.AddSingleton<IPasswordHasher, PasswordHasher>();
            });

            return host;
        }
    }
}
