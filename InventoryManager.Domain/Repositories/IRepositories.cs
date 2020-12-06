using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Repositories
{
    public interface IRepositories<T>
    {
        Task<T> Get(int Id);
    }
}
