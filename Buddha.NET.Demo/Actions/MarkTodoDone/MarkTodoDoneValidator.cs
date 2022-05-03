using Buddha.NET.Demo.Services;
using Buddha.NET.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buddha.NET.Demo.Actions.MarkTodoDone
{
    public class MarkTodoDoneValidator : Validator<MarkTodoDoneRequest>
    {
        private TodoService TodoService { get; }

        public MarkTodoDoneValidator(TodoService todoService)
        {
            TodoService = todoService;
        }

        protected override IList<ValidationConstraint<MarkTodoDoneRequest>> Constraints => new List<ValidationConstraint<MarkTodoDoneRequest>>
        {
            new ValidationConstraint<MarkTodoDoneRequest>(_ => Task.FromResult(!string.IsNullOrEmpty(_.TodoId)), _ => "Todo ID must not be empty", _ => _.TodoId),
            new ValidationConstraint<MarkTodoDoneRequest>(async _ => TodoService.GetTodoById(_.TodoId) is not null, _ => $"Todo by ID '{_.TodoId}' was not found")
        };
    }
}
