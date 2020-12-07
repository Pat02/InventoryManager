using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using InventoryManager.Domain.Models;

namespace InventoryManager.EntityFramework
{
    public class InventoryManagerDbContext : DbContext
    {

        public InventoryManagerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Container> Containers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Container>().HasKey("_id");
            modelBuilder.Entity<Item>().HasKey("_id");
            modelBuilder.Entity<Inventory>().HasKey("id");
            modelBuilder.Entity<InventoryItem>().HasKey("id");
            base.OnModelCreating(modelBuilder);
        }
    }
}
