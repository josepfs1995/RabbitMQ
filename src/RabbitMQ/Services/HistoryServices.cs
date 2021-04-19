using System;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Domain.Interfaces;
using RabbitMQ.Domain.Model;
using RabbitMQ.Proxy;

namespace RabbitMQ.Services{
    public class HistoryServices:BackgroundService{
         private readonly IMessageBus _messageBus;
        private readonly IServiceProvider _serviceProvider;
        public HistoryServices(IServiceProvider serviceProvider, IMessageBus messageBus)
        {
            _serviceProvider = serviceProvider;
            _messageBus = messageBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {  
            await _messageBus.RespondAsync<History, bool>(Retornar);
        }
        private bool Retornar(History request){
           using (var scope = _serviceProvider.CreateScope())
            {
                var historyRepository = scope.ServiceProvider.GetRequiredService<IHistoryRepository>();
                historyRepository.Create(request);
            }
            return true;
        }
    }
}