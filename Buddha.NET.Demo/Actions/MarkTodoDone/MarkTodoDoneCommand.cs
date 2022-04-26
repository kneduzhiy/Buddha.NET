using Buddha.NET.Demo.Services;

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

        public override Response<MarkTodoDoneResponse> Handle(MarkTodoDoneRequest request)
        {
            var validationResult = Validator.Validate(request);
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
