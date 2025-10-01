using System;
using ServerApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using ServerApp.Services.Interfaces;
using ServerApp.Repositories.Interfaces;

namespace ServerApp.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task SendMessageAsync(int customerId, string MessageText)
        {
            var message = new Message
            {
                MessageSender = customerId,
                MessageText = MessageText,
                CreatedAt = DateTime.UtcNow
            };

            await _messageRepository.AddMessageAsync(message);
        }
        public async Task<List<Message>> GetCustomerMessagesAsync(int customerId)
        {
            return await _messageRepository.GetMessagesByCustomerIdAsync(customerId);
        }
    }
}