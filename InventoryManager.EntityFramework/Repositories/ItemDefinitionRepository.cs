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
    public class ItemDefinitionRepository : IRepository<ItemDefinition>
    {
        protected readonly IDataService<ItemDefinition> dataService;

        public ItemDefinitionRepository(GenericDataService<ItemDefinition> dataService)
        {
            this.dataService = dataService;
        }

        public async Task<ItemDefinition> Get(Guid Id)
        {
            return await dataService.Get(Id);
        }
        /// <summary>
        /// This function grabs all items from the DnD api as well as the database
        /// </summary>
        /// <returns>AsyncEnumerable of Items</returns>
        public async Task<IAsyncEnumerable<ItemDefinition>> GetAll()
        {

            return await dataService.GetAll();
        }

        public async Task<bool> Remove(Guid Id)
        {
            return await dataService.Remove(Id);
        }

        public async Task<bool> RemoveAll(IEnumerable<ItemDefinition> list)
        {
            await dataService.RemoveAll(list);
            return true;
        }
    }
}
