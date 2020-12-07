using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Get(int Id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Remove(int Id);
        Task<T> RemoveAll(IEnumerable<T> list);
        Task<T> Find(Expression<Func<T>> filter);
    }
}
