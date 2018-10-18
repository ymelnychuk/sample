using Dapper;
using Sample.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private IConnectionFactory _factory;
        private readonly String _baseQuery;

        public BaseRepository(IConnectionFactory factory, String baseQuery)
        {
            _factory = factory;
            _baseQuery = baseQuery;
        }

        public IEnumerable<T> GetAll()
        {
            var list = new List<T>();
            using (var context = _factory.CreateConnection())
            {
                list = context.Query<T>(_baseQuery).ToList();
            }
            return list;
        }

        public IEnumerable<T> GetAll(int pageIndex, int pageSize, string orderBy)
        {
            var list = new List<T>();
            string sql = String.Format(
@"SELECT  *
FROM(SELECT    ROW_NUMBER() OVER(ORDER BY {0}) AS RowNum, *
          FROM      dbo.Product
        ) AS RowConstrainedResult
WHERE RowNum > {1}
    AND RowNum <= {2}
ORDER BY RowNum",
orderBy, pageIndex * pageSize - pageSize, pageIndex * pageSize);
            using (var context = _factory.CreateConnection())
            {
                list = context.Query<T>(sql).ToList();
            }
            return list;
        }

        public int GetAllCount()
        {
            Int32 total = 0;
            //var sql = $"select count(*) from ({_baseQuery}) x";
            using (var context = _factory.CreateConnection())
            {
                total = context.ExecuteScalar<int>("SELECT COUNT(*) FROM Product");
            }
            return total;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
