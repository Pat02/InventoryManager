using System;
using InventoryManager.DnD5eAPI;
using InventoryManager.Domain.Models;
using InventoryManager;
using InventoryManager.EntityFramework;
using InventoryManager.EntityFramework.Services;
using System.Collections.Generic;
using InventoryManager.DnD5eAPI.Results;
using InventoryManager.DnD5eAPI.Services;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using InventoryManager.DnD5eAPI.Models;
using InventoryManager.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace TestConsoleApp
{
    class Program
    {
        private static Guid CreateGuid()
        {
            return Guid.NewGuid();
        }

        static async Task Main(string[] args)
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder<InventoryManagerDbContext>();
            options.UseSqlite(@"Data Source=InventoryManager.db;");
            using (InventoryManagerDbContext context = new InventoryManagerDbContext(options.Options))
            {
                context.Database.Migrate();
            }
            Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(@"Data Source=InventoryManager.db;");

            InventoryManagerDbContextFactory contextFactory = new InventoryManagerDbContextFactory(configureDbContext);
            IDataService<Container> dataService = new GenericDataService<Container>(contextFactory);

            Item item1 = new Item() { id = CreateGuid(), Name = "Test Item of Valor", Weight = 1 };
            Item item2 = new Item() { id = CreateGuid(), Name = "Test Item of Valor", Weight = 1 };
            Item item3 = new Item() { id = CreateGuid(), Name = "Test Item of Valor", Weight = 1 };

            List<IStorable> containerItems = new List<IStorable>();
            containerItems.Add(new ContainerItem() { id = CreateGuid(), Item = item1, Quantity = 3 });
            containerItems.Add(new ContainerItem() { id = CreateGuid(), Item = item2, Quantity = 5 });
            containerItems.Add(new ContainerItem() { id = CreateGuid(), Item = item3, Quantity = 1 });
            Container container = new Container() { id = CreateGuid(), Inventory = containerItems, Name = "Test container", Weight = 3 };
            var thing = await dataService.Create(container);

            var newthing = await dataService.Get(thing.id);
            Console.WriteLine("Great success!");
        }
    }
}