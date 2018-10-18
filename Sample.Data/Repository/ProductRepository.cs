using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Data.Entity;

namespace Sample.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private const string _baseQuery = "select * from Product";
        public ProductRepository() : base(new SqlConnectionFactory(), _baseQuery)  { }
    }
}
