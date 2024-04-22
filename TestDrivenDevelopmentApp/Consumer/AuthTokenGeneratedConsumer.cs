using Contracts;
using MassTransit;

namespace TestDrivenDevelopmentApp.Consumer
{
    public sealed class AuthTokenGeneratedConsumer : IConsumer<AuthTokenGeneratedEvent>
    {
        private readonly TaskCompletionSource<string> _tokenCompletionSource = new TaskCompletionSource<string>();

        public Task Consume(ConsumeContext<AuthTokenGeneratedEvent> context)
        {
            _tokenCompletionSource.TrySetResult(context.Message.Token);
            Console.WriteLine($"Token generated: {context.Message.Token}");
            return Task.CompletedTask;
        }

        public Task<string> GetToken()
        {
            return _tokenCompletionSource.Task;
        }
    }
}
