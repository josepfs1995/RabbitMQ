using System.Collections.Generic;
using RabbitMQ.Domain.Interfaces;
using RabbitMQ.Domain.Model;

namespace RabbitMQ.Infra.Repository{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly ICollection<History> History;
        public HistoryRepository(ICollection<History> history)
        {
            History = history;
        }
       
        public void Create(History model)
        {
           History.Add(model);
        }
        public IEnumerable<History> GetAll()
        {
            return History;
        }
    }
}