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
            IDataService<Item> dataService = new GenericDataService<Item>(contextFactory);
            Guid testGuid = Guid.NewGuid();
            Item item = new Item() {id = testGuid, Name = "Test Item of Valor", Weight = 1 };

            var i = dataService.Create(item).Result;

            var retrievedItem = dataService.Get(testGuid).Result;
            Console.WriteLine($"Name: {retrievedItem.Name}\n Weight: {retrievedItem.Weight}");

        }
    }
}
