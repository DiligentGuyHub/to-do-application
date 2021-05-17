using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WPF.ViewModels;

namespace ToDo.WPF.HostBuilders
{
    public static class AddViewHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            });

            return host;
        }
    }
}
