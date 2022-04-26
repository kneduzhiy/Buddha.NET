using System;
using System.Threading.Tasks;

namespace Buddha.NET
{
    public class Buddha
    {
        public IServiceProvider ServiceProvider { get; }

        public Buddha(IServiceProvider provider)
        {
            ServiceProvider = provider;
        }

        public async Task<Response<TResponse>> HandleCommand<TCommand, TRequest, TResponse>(TRequest request)
            where TCommand : Command<TRequest, TResponse>
            where TRequest : class
            where TResponse : class
        {
            var command = ServiceProvider.GetService(typeof(TCommand)) as TCommand;

            var response = command.Handle(request);
            if (response is null)
            {
                response = await command.HandleAsync(request);
            }

            return response;
        }
    }
}
