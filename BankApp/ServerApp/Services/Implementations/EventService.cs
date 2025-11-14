using System;
using Prometheus;
using MongoDB.Driver;
using ServerApp.Models;
using System.Threading.Tasks;
using ServerApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;


namespace ServerApp.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IMongoCollection<CreditApplicationEvent> _collection;
        private static readonly Counter CreditApplicationCounter = Metrics
            .CreateCounter("credit_application_total", "Toplam kredi başvurusu sayısı",
                           new CounterConfiguration { LabelNames = new[] { "status" } });

        public EventService(IConfiguration configuration)
        {
            var mongoSettings = configuration.GetSection("MongoDbSettings");
            var client = new MongoClient(mongoSettings.GetValue<string>("ConnectionString"));
            var database = client.GetDatabase(mongoSettings.GetValue<string>("DatabaseName"));
            _collection = database.GetCollection<CreditApplicationEvent>("CreditApplicationEvents");
        }
        public async Task LogCreditApplicationEventAsync(CreditApplicationEvent creditEvent)
        {
            creditEvent.CreatedAt = DateTime.UtcNow;
            await _collection.InsertOneAsync(creditEvent);

            CreditApplicationCounter.Labels(creditEvent.Status).Inc();
        }
    }
}
