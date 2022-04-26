using Buddha.NET.Demo.Services;

namespace Buddha.NET.Demo.Actions
{
    public class GetTodosCommand : Command<GetTodosRequest, GetTodosResponse>
    {
        private TodoService TodoService { get; }

        public GetTodosCommand(TodoService todoService)
        {
            TodoService = todoService;
        }

        public override Response<GetTodosResponse> Handle(GetTodosRequest request)
        {
            bool includeDone = request.IncludeDone;
            var response = new GetTodosResponse
            {
                Todos = includeDone ? TodoService.GetTodos(includeDone: true) : TodoService.GetTodos()
            };

            return new Response<GetTodosResponse>
            {
                Success = true,
                Data = response
            };
        }
    }
}
