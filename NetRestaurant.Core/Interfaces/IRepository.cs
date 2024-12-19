using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetRestaurant.Core.Interfaces
{
    public interface IRepository<T>
    {
        T Get(Int64 id);
        IList<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        Boolean Delete(Int64 id);
    }
}
