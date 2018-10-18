using Sample.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Int32 GetAllCount();
        IEnumerable<T> GetAll(int pageNumber, int pageSize, String orderBy);
        T GetById(int id);
        // TODO: Insert, Update, Delete
    }
}
