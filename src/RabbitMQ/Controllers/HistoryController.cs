using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Domain.Interfaces;

namespace RabbitMQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryRepository _historyRepository;
        public HistoryController(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_historyRepository.GetAll());
        }
        
    }
}
