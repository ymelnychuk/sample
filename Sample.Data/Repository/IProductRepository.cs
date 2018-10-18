using Sample.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
