using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using InventoryManager.EntityFramework;
using Microsoft.EntityFrameworkCore;
using InventoryManager.Domain.Services;
using InventoryManager.EntityFramework.Services;
using InventoryManager.Domain.Models;
using InventoryManager.Domain.Repositories;

namespace InventoryManager.WPF.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(@"Data Source=InventoryManager.db;");
            services.AddDbContext<InventoryManagerDbContext>(configureDbContext);
            services.AddScoped<IDataService<Item>, GenericDataService<Item>>();
            services.AddScoped<IRepository<Item>, ItemRepository>();
            services.AddSingleton<InventoryManagerDbContextFactory>(new InventoryManagerDbContextFactory(configureDbContext));
            DbContextOptionsBuilder options = new DbContextOptionsBuilder<InventoryManagerDbContext>();
            options.UseSqlite(@"Data Source=InventoryManager.db;");
            using(InventoryManagerDbContext context = new InventoryManagerDbContext(options.Options))
            {
                context.Database.Migrate();
            }

            return services.BuildServiceProvider();
        }
    }
}
