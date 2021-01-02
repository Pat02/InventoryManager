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

            ItemDefinition item1 = new ItemDefinition() { id = CreateGuid(), Name = "Test Item of Valor", Weight = 1 };
            ItemDefinition item2 = new ItemDefinition() { id = CreateGuid(), Name = "Test Item of Valor", Weight = 1 };
            ItemDefinition item3 = new ItemDefinition() { id = CreateGuid(), Name = "Test Item of Valor", Weight = 1 };

            List<StorableItem> containerItems = new List<StorableItem>();
            containerItems.Add(new ContainerItem() { id = CreateGuid(), ItemDefinition = item1, Quantity = 3 });
            containerItems.Add(new ContainerItem() { id = CreateGuid(), ItemDefinition = item2, Quantity = 5 });
            containerItems.Add(new ContainerItem() { id = CreateGuid(), ItemDefinition = item3, Quantity = 1 });
            Container container = new Container() { id = CreateGuid(), Inventory = containerItems};
            container.ItemDefinition.Name = "Test Container";
            container.ItemDefinition.Weight = 3;
            var thing = await dataService.Create(container);

            var newthing = await dataService.Get(thing.id);
            Console.WriteLine("Great success!");
        }
    }
}