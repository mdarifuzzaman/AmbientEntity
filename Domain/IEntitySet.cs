using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IEntitySet<T> : IQueryable<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        void Remove(T entity);
    }
}
