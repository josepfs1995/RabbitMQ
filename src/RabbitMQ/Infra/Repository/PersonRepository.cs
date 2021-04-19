using System;
using System.Collections.Generic;
using RabbitMQ.Domain.Interfaces;
using RabbitMQ.Domain.Model;

namespace RabbitMQ.Infra.Repository{
    public class PersonRepository : IPersonRepository
    {
        private readonly ICollection<Person> People;
        public PersonRepository(ICollection<Person> people)
        {
            People = people;
        }
        public void Create(Person model)
        {
            model.Id = Guid.NewGuid();
            People.Add(model);
        }
        public IEnumerable<Person> GetAll()
        {
            return People;
        }
    }
}