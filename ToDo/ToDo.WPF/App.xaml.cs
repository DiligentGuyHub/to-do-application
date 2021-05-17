using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NbrbAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ToDo.API.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Services;
using ToDo.Domain.Services.AuthenticationServices;
using ToDo.EntityFramework;
using ToDo.EntityFramework.Services;
using ToDo.EntityFramework.Services.Common;
using ToDo.WPF.HostBuilders;
using ToDo.WPF.State.Accounts;
using ToDo.WPF.State.Authenticators;
using ToDo.WPF.State.Navigators;
using ToDo.WPF.State.Settings;
using ToDo.WPF.State.Tasks;
using ToDo.WPF.ViewModels;
using ToDo.WPF.ViewModels.Factories;

namespace ToDo.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    // for config + sql connection string + migration
    // singleton - one instance per application
    // transient - different instance everytime
    // scoped - one instance per scope
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = CreateHostBuilder().Build();
        }
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddConfiguration()
                .AddDbContext()
                .AddServices()
                .AddStores()
                .AddViewModels()
                .AddViews();
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            ToDoDbContextFactory contextFactory = _host.Services.GetRequiredService<ToDoDbContextFactory>();
            using (ToDoDbContext context = contextFactory.CreateDbContext())
            {
                context.Database.Migrate();
            }

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }
    }
}
