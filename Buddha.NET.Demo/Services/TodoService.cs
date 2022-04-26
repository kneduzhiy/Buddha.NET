using Buddha.NET.Demo.Model;
using System.Collections.Generic;
using System.Linq;
using NanoIdGenerator = Nanoid.Nanoid;

namespace Buddha.NET.Demo.Services
{
    /// <summary>
    /// Demo CRUD service with a local list, just for demonstration purposes!
    /// In real life you'd inject an EF Core DBContext here and handle stuff with a DB in the background.
    /// And before: best implement a BaseService'TEntity class for generic CRUD handling.
    /// </summary>
    public class TodoService
    {
        private IList<Todo> LocalTodos { get; } = new List<Todo>
            {
                new Todo
                {
                    Id = NanoIdGenerator.Generate(),
                    Name = "Make a pizza",
                    Done = true
                },
                new Todo
                {
                    Id = NanoIdGenerator.Generate(),
                    Name = "Eat the pizza",
                    Done = false
                }
            };

        public Todo GetTodoById(string id) => LocalTodos.FirstOrDefault(_ => _.Id == id);
        public List<Todo> GetTodos(bool includeDone = false) => LocalTodos.Where(_ => !includeDone ? !_.Done : (_.Done || !_.Done)).ToList();

        public Todo AddTodo(Todo todo)
        {
            todo.Id = NanoIdGenerator.Generate();
            LocalTodos.Add(todo);

            return todo;
        }

        public Todo UpdateTodo(Todo todo)
        {
            var existingTodo = LocalTodos.FirstOrDefault(_ => todo.Id == _.Id);
            if (existingTodo is null)
            {
                return null;
            }

            todo.Id = existingTodo.Id;
            LocalTodos.RemoveAt(LocalTodos.IndexOf(existingTodo));

            LocalTodos.Add(todo);
            return todo;
        }
    }
}
