using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using WebApplicationTest.Models;
using WebApplicationTest.Settings;

namespace WebApplicationTest.Data.Services
{
    public class UserRepository : IUserRepository
    {
        public DbConnection GetDbconnection()
        {
            return new SqlConnection(Config.DefaultConnection);
        }

        public User GetUserById(int id)
        {
            return null;
        }

        public IEnumerable<User> GetUsers()
        {
            using (IDbConnection dataBase = GetDbconnection())
            {
                return dataBase.Query<User>("SELECT * FROM Users");
            }
        }
    }
}
