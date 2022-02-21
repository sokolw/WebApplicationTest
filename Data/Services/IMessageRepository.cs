using System.Data.Common;
using WebApplicationTest.Models;

namespace WebApplicationTest.Data.Services
{
    public interface IMessageRepository
    {
        DbConnection GetDbconnection();
        IEnumerable<Message> GetMessages();
        Message GetMessageById(int id);
        void CreateMessage(Message message);
        void DeleteMessageById(int id);
    }
}
