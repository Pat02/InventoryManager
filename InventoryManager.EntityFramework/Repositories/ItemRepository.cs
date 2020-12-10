using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.Domain.Models;
using InventoryManager.Domain.Repositories;
using InventoryManager.Domain.Services;
using InventoryManager.EntityFramework.Services;
using System.Linq;

namespace InventoryManager.EntityFramework.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        protected readonly IDataService<Item> dataService;

        public ItemRepository(GenericDataService<Item> dataService)
        {
            this.dataService = dataService;
        }

        public async Task<Item> Get(Guid Id)
        {
            return await dataService.Get(Id);
        }

        public async Task<IAsyncEnumerable<Item>> GetAll()
        {
            return await dataService.GetAll();
        }

        public async Task<bool> Remove(Guid Id)
        {
            return await dataService.Remove(Id);
        }

        public async Task<bool> RemoveAll(IEnumerable<Item> list)
        {
            await dataService.RemoveAll(list);
            return true;
        }
    }
}
