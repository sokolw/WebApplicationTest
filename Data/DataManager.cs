using WebApplicationTest.Data.Services;

namespace WebApplicationTest.Data
{
    public class DataManager
    {
        public IUserRepository Users { get; set; }
        public IMessageRepository Messages { get; set; }
        public DataManager(IUserRepository userRepository, IMessageRepository messageRepository)
        {
            Users = userRepository;
            Messages = messageRepository;
        }

    }
}
