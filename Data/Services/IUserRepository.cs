using System.Data.Common;
using WebApplicationTest.Models;

namespace WebApplicationTest.Data.Services
{
    public interface IUserRepository
    {
        DbConnection GetDbconnection();
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
    }
}
