using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.EntityFramework;

namespace ToDo.WPF.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                // to not depend on implementations -> only interfaces matter
                string connectionString = context.Configuration.GetConnectionString("default");
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlServer(connectionString);
                services.AddDbContext<ToDoDbContext>(configureDbContext);
                services.AddSingleton<ToDoDbContextFactory>(new ToDoDbContextFactory(connectionString));
            });

            return host;
        }
    }
}
