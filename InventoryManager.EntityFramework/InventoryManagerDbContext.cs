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
        public DbSet<Container> Containers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasKey("id");
            base.OnModelCreating(modelBuilder);
        }
    }
}
