using InventoryManager.Domain.Models;
using InventoryManager.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : Trackable
    {
        private readonly InventoryManagerDbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        public GenericDataService(InventoryManagerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<T>(contextFactory);
        }

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<T> Get(Guid id)
        {
            using (InventoryManagerDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.id == id);
                return entity;
            }
        }

        public async Task<T> Update(Guid id,T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
