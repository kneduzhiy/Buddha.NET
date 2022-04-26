using Buddha.NET.AspNetCore;
using Buddha.NET.Demo.Actions;
using Buddha.NET.Demo.Actions.CreateTodo;
using Buddha.NET.Demo.Actions.MarkTodoDone;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Buddha.NET.Demo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodosController : BuddhaController
    {
        public TodosController(Buddha buddha) : base(buddha) { }

        [HttpGet]
        public Task<IActionResult> GetTodos([FromQuery] bool showDone = false) => BuddhaResponse<GetTodosCommand, GetTodosRequest, GetTodosResponse>(new GetTodosRequest { IncludeDone = showDone });

        [HttpPost]
        public Task<IActionResult> AddTodo([FromBody] CreateTodoRequest request) => BuddhaResponse<CreateTodoCommand, CreateTodoRequest, CreateTodoResponse>(request);

        [Route("{todoId}")]
        [HttpPatch]
        public Task<IActionResult> MarkTodoDone(string todoId) => BuddhaResponse<MarkTodoDoneCommand, MarkTodoDoneRequest, MarkTodoDoneResponse>(new MarkTodoDoneRequest { TodoId = todoId });
    }
}
