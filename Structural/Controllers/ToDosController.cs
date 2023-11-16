using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YourApiName.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        // Constructor injection to get an instance of ITodoRepository
        public TodosController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        // Retrieve all todo items
        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _todoRepository.GetAll();
            return Ok(todos);
        }

        // Retrieve a todo item by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _todoRepository.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // Add a new todo item
        [HttpPost]
        public IActionResult AddTodo([FromBody] TodoItem todo)
        {
            _todoRepository.Add(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        // Update an existing todo item
        [HttpPut("{id}")]
        public IActionResult UpdateTodo(int id, [FromBody] TodoItem todo)
        {
            var existingTodo = _todoRepository.GetById(id);
            if (existingTodo == null)
            {
                return NotFound();
            }
            _todoRepository.Update(todo);
            return NoContent();
        }

        // Delete a todo item by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            var existingTodo = _todoRepository.GetById(id);
            if (existingTodo == null)
            {
                return NotFound();
            }
            _todoRepository.Delete(id);
            return NoContent();
        }
    }
}
