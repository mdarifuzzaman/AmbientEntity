using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository
    {
        Task Add(IProduct product);

        Task<IProduct> Get(string id);

        Task<IEnumerable<IProduct>> GetAll();
    }
}
