using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Repository
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Action1"].ConnectionString);
        }
    }
}
