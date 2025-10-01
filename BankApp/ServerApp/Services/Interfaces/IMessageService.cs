using ServerApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ServerApp.Services.Interfaces
{
    public interface IMessageService
    {
        Task SendMessageAsync(int customerId, string MessageText);
        Task<List<Message>> GetCustomerMessagesAsync(int customerId);
    }
}