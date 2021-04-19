using System;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Internals;

namespace RabbitMQ.Proxy{
    public class MessageBus : IMessageBus
    {
        public IBus _bus { get; set; }
        private readonly string _connectionString;
        public MessageBus(string connectionString)
        {
            _connectionString = connectionString;
            Connect();
        }
        public bool IsConnected => _bus?.Advanced?.IsConnected ?? false;

        public Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
        {
            Connect();
            return _bus.Rpc.RequestAsync<TRequest, TResponse>(request);
        }

        public AwaitableDisposable<IDisposable> RespondAsync<TRequest, TResponse>(Func<TRequest, TResponse> response)
        {
            Connect();
            return _bus.Rpc.RespondAsync<TRequest, TResponse>(response);
        }
        private void Connect(){
            if(IsConnected) return;
            _bus = RabbitHutch.CreateBus(_connectionString);
        }
    }
}