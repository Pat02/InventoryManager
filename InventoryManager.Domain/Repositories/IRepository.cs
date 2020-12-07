using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Get(int Id);
        Task<T> GetAll();
        Task<T> Remove(int Id);
        Task<T> RemoveAll();
        Task<T> Find(Predicate<T> filter);
    }
}
