using Buddha.NET.Model;
using System.Collections.Generic;

namespace Buddha.NET.Demo.Actions.CreateTodo
{
    public class CreateTodoValidator : Validator<CreateTodoRequest>
    {
        protected override IList<ValidationConstraint<CreateTodoRequest>> Constraints => new List<ValidationConstraint<CreateTodoRequest>>
        {
            new ValidationConstraint<CreateTodoRequest>(async _ => !string.IsNullOrEmpty(_.Name), _ => "Name was empty")
        };
    }
}
