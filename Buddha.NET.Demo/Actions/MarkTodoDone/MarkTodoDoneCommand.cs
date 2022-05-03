using Buddha.NET.Demo.Services;
using System.Threading.Tasks;

namespace Buddha.NET.Demo.Actions.MarkTodoDone
{
    public class MarkTodoDoneCommand : Command<MarkTodoDoneRequest, MarkTodoDoneResponse>
    {
        private TodoService TodoService { get; }

        public MarkTodoDoneCommand(MarkTodoDoneValidator validator, TodoService todoService)
        {
            Validator = validator;
            TodoService = todoService;
        }

        public override async Task<Response<MarkTodoDoneResponse>> HandleAsync(MarkTodoDoneRequest request)
        {
            var validationResult = await Validator.Validate(request);
            if (validationResult.ValidationFailed)
            {
                return Validator.GenerateErrorResponse<MarkTodoDoneResponse>(validationResult.FailedValidationItems);
            }

            var todoToUpdate = TodoService.GetTodoById(request.TodoId);
            todoToUpdate.Done = true;

            var updatedTodo = TodoService.UpdateTodo(todoToUpdate);
            var result = new MarkTodoDoneResponse
            {
                TodoId = updatedTodo.Id,
                Done = updatedTodo.Done
            };

            return new Response<MarkTodoDoneResponse>
            {
                Success = true,
                Data = result
            };
        }
    }
}
