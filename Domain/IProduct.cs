using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IProduct: IEntity
    {
        string ProductId { get; set; }

        string ProductName { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateModified { get; set; }

        string Description { get; set; }
    }
}
