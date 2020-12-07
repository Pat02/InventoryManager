using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Services
{
    public interface IDataService<T>
    {
        Task<T> Get(Guid id);
        Task<T> Create(T entity);
        Task<T> Update(Guid id, T entity);
        Task<bool> Delete(Guid id);
    }
}
