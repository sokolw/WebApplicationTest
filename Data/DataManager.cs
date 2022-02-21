using WebApplicationTest.Data.Services;

namespace WebApplicationTest.Data
{
    public class DataManager
    {
        public IUserRepository Users { get; set; }
        public DataManager(IUserRepository userRepository)
        {
            Users = userRepository;
        }

    }
}
