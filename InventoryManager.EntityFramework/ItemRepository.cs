using System;
using System.Collections.Generic;
using System.Text;
using InventoryManager.Domain.Models;
using InventoryManager.Domain.Repositories;
using InventoryManager.Domain.Services;
using InventoryManager.EntityFramework.Services;

namespace InventoryManager.EntityFramework
{
    public class ItemRepository : IRepository<Item>
    {
        protected readonly IDataService<Item> dataService;

        public ItemRepository(GenericDataService<Item> dataService)
        {
            this.dataService = dataService;
        }

        public async System.Threading.Tasks.Task<Item> Find(System.Linq.Expressions.Expression<Func<Item>> filter)
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task<Item> Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task<IEnumerable<Item>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task<Item> Remove(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task<Item> RemoveAll(IEnumerable<Item> list)
        {
            throw new NotImplementedException();
        }
    }
}
