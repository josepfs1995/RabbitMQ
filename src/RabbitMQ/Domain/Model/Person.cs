using System;

namespace RabbitMQ.Domain.Model{
    public class Person{
        public Person(Guid id, string firstName, string surname)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}