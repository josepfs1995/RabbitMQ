using System.Collections.Generic;
using RabbitMQ.Domain.Model;

namespace RabbitMQ.Domain.Interfaces{
    public interface IHistoryRepository{
        IEnumerable<History> GetAll();
        void Create(History model);
    }
}