using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Buddha.NET.AspNetCore
{
    public class BuddhaController : ControllerBase
    {
        protected Buddha Buddha { get; }
        public BuddhaController(Buddha buddha)
        {
            Buddha = buddha;
        }

        protected async Task<IActionResult> BuddhaResponse<TCommand, TRequest, TResponse>(TRequest request)
            where TCommand : Command<TRequest, TResponse>
            where TRequest : class
            where TResponse : class
        {
            var result = await Buddha.HandleCommand<TCommand, TRequest, TResponse>(request);
            return Ok(result);
        }
    }
}
