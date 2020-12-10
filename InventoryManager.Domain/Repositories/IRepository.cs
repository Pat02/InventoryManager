using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Get(Guid Id);
        Task<IAsyncEnumerable<T>> GetAll();
        Task<bool> Remove(Guid Id);
        Task<bool> RemoveAll(IEnumerable<T> list);
    }
}
