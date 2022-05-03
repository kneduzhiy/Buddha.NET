using Buddha.NET.Demo.Model;
using Buddha.NET.Demo.Services;
using System.Threading.Tasks;

namespace Buddha.NET.Demo.Actions.CreateTodo
{
    public class CreateTodoCommand : Command<CreateTodoRequest, CreateTodoResponse>
    {
        private TodoService TodoService { get; }

        public CreateTodoCommand(TodoService todoService)
        {
            TodoService = todoService;
            Validator = new CreateTodoValidator();
        }

        public override async Task<Response<CreateTodoResponse>> HandleAsync(CreateTodoRequest request)
        {
            var validationResult = await Validator.Validate(request);
            if (validationResult.ValidationFailed)
            {
                return Validator.GenerateErrorResponse<CreateTodoResponse>(validationResult.FailedValidationItems);
            }

            var addedTodo = TodoService.AddTodo(new Todo
            {
                Name = request.Name
            });

            var response = new CreateTodoResponse
            {
                Result = addedTodo
            };

            return new()
            {
                Success = true,
                Data = response
            };
        }
    }
}
