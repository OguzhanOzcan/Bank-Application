using System.Linq;
using ServerApp.Data;
using ServerApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ServerApp.Repositories.Interfaces;

namespace ServerApp.Repositories.Implementations
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _db;
        public MessageRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddMessageAsync(Message message)
        {
            await _db.Messages.AddAsync(message);
            await _db.SaveChangesAsync();
        }
        public async Task<List<Message>> GetMessagesByCustomerIdAsync(int customerId)
        {
            return await _db.Messages
                .Where(m => m.MessageSender == customerId)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();
        }
    }
}

