using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using WebApplicationTest.Models;
using WebApplicationTest.Settings;

namespace WebApplicationTest.Data.Services
{
    public class MessageRepository : IMessageRepository
    {
        public DbConnection GetDbconnection()
        {
            return new SqlConnection(Config.DefaultConnection);
        }

        public IEnumerable<Message> GetMessages()
        {
            using (IDbConnection dataBase = GetDbconnection())
            {
                return dataBase.Query<Message>("SELECT * FROM Messages");
            }
        }
        public Message GetMessageById(int id)
        {
            using (IDbConnection dataBase = GetDbconnection())
            {
                return dataBase.Query<Message>($"SELECT * FROM Messages WHERE Id={id};").First();
            }
        }
        public void CreateMessage(Message message)
        {
            using (IDbConnection dataBase = GetDbconnection())
            {
                dataBase.Query<Message>($"INSERT INTO Messages (Text, Email, Phone, Date) VALUES ('{message.Text}', '{message.Email}', '{message.Phone}', '{message.Date}')");
            }
        }
        public void DeleteMessageById(int id)
        {
            using (IDbConnection dataBase = GetDbconnection())
            {
                dataBase.Query<Message>($"DELETE FROM Messages WHERE Id={id};");
            }
        }
    }
}
