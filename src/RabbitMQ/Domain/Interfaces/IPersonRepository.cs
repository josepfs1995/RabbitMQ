using System.Collections.Generic;
using System.Threading.Tasks;
using RabbitMQ.Domain.Model;

namespace RabbitMQ.Domain.Interfaces{
    public interface IPersonRepository{
        IEnumerable<Person> GetAll();
        void Create(Person model);
    }
}