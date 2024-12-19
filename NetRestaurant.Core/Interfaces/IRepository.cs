using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetRestaurant.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> Get(Int64 id);
        Task<IList<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<Boolean> Delete(Int64 id);
    }
}
