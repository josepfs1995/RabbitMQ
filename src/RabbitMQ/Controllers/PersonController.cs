using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Domain.Interfaces;
using RabbitMQ.Domain.Model;
using RabbitMQ.Proxy;

namespace RabbitMQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMessageBus _messageBus;
        public PersonController(IPersonRepository personRepository, IMessageBus messageBus)
        {
            _personRepository = personRepository;
            _messageBus = messageBus;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personRepository.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Person model)
        {
            _personRepository.Create(model);

            var history = new History(nameof(Person), "Created");
            var response = await CreatedHistory(history);
            if(!response) return BadRequest();
            return Ok();
        }

        private async Task<bool> CreatedHistory(History history){
            return await _messageBus.RequestAsync<History, bool>(history);
        }
    }
}
