using System.Threading.Tasks;

namespace Buddha.NET
{
    public class Command<TRequest, TResponse> where TRequest : class
                                              where TResponse : class
    {
        public Validator<TRequest> Validator { get; protected set; }

        public virtual Response<TResponse> Handle(TRequest request) => null;
        public virtual Task<Response<TResponse>> HandleAsync(TRequest request) => null;
    }
}
