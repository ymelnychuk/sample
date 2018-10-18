using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Entity
{
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        //public Category Category { get; set; }
    }
}
