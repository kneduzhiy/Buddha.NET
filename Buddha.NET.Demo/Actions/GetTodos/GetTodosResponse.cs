using Buddha.NET.Demo.Model;
using System.Collections.Generic;

namespace Buddha.NET.Demo.Actions
{
    public class GetTodosResponse
    {
        public IList<Todo> Todos { get; set; }
    }
}
