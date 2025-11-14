using System.Threading.Tasks;
using ServerApp.Models;

namespace ServerApp.Services.Interfaces
{
    public interface IEventService
    {
        Task LogCreditApplicationEventAsync(CreditApplicationEvent creditEvent);
    }
}
