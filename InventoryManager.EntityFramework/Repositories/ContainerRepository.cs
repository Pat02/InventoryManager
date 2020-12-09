using InventoryManager.Domain.Models;
using InventoryManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.EntityFramework.Repositories
{
    public class ContainerRepository : IRepository<Container>
    {
        public Task<Container> Find(Expression<Func<Container>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Container> Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Container>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Container> Remove(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Container> RemoveAll(IEnumerable<Container> list)
        {
            throw new NotImplementedException();
        }
    }
}
