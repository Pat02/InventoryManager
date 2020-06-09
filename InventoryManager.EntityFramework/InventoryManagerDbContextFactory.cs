using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InventoryManager.EntityFramework
{
    class InventoryManagerDbContextFactory : IDesignTimeDbContextFactory<InventoryManagerDbContext>
    {
        public InventoryManagerDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<InventoryManagerDbContext>();
            options.UseSqlite(@"Data Source=InventoryManager.db;");
            return new InventoryManagerDbContext(options.Options);
        }
    }
}
