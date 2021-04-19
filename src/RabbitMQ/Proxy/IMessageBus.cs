using System;
using System.Threading.Tasks;
using EasyNetQ.Internals;

namespace RabbitMQ.Proxy{
    public interface IMessageBus{
        bool IsConnected { get; }
        Task<TResponse> RequestAsync<TRequest,TResponse>(TRequest request);
        AwaitableDisposable<IDisposable> RespondAsync<TRequest, TResponse>(Func<TRequest, TResponse> response);
    }

}