using System;

namespace RabbitMQ.Domain.Model{
    public class History{
        public History(string table, string action)
        {
            Id = Guid.NewGuid();
            Table = table;
            Action = action;
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Table { get; set; }
        public string Action { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}