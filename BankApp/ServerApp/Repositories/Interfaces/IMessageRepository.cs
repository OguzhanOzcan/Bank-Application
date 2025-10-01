using ServerApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ServerApp.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task AddMessageAsync(Message message);
        Task<List<Message>> GetMessagesByCustomerIdAsync(int customerId);
    }
}