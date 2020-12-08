using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InventoryManager.EntityFramework
{
    public class InventoryManagerDbContextFactory : IDesignTimeDbContextFactory<InventoryManagerDbContext>
    {
        private readonly Action<DbContextOptionsBuilder> configureDbContext;

        public InventoryManagerDbContextFactory()
        {
            configureDbContext = o => o.UseSqlite(@"Data Source=InventoryManager.db;");
        }

        public InventoryManagerDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            this.configureDbContext = configureDbContext;
        }

        public InventoryManagerDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<InventoryManagerDbContext>();
            configureDbContext(options);
            return new InventoryManagerDbContext(options.Options);
        }
    }
}
