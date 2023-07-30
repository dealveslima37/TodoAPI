using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Data;
using TodoAPI.DTOs;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("todos")]
        public IActionResult Post([FromBody] TodoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var todo = new Todo(dto.Title, false, DateTime.Now);

            try
            {
                _context.Todos.Add(todo);
                _context.SaveChanges();

                var todoSummaryDto = new TodoSummaryDto
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Done = todo.Done,
                    CreatedAt = todo.CreatedAt,
                };

                return Created($"v1/todos/{todo.Id}", todoSummaryDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return BadRequest();
            }
        }

        [HttpGet("todos")]
        public IActionResult GetAll()
        {
            var todos = _context.Todos.Select(todo => new TodoSummaryDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Done = todo.Done,
                CreatedAt = todo.CreatedAt,
            }).ToList();

            return Ok(todos);
        }

        [HttpGet("todos/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null) return NotFound();

            var todoSummaryDto = new TodoSummaryDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Done = todo.Done,
                CreatedAt = todo.CreatedAt,
            };

            return Ok(todoSummaryDto);
        }

        [HttpPut("todos/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] TodoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null) return NotFound();

            try
            {
                todo.Title = dto.Title;
                todo.UpdateAt = DateTime.Now;

                _context.Todos.Update(todo);
                _context.SaveChanges();

                var todoSummaryUpdateDto = new TodoSummaryUpdateDto
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Done = todo.Done,
                    UpdateAt = todo.UpdateAt
                };

                return Ok(todoSummaryUpdateDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return BadRequest();
            }
        }

        [HttpPatch("todos/{id}")]
        public IActionResult Patch([FromRoute] int id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null) return NotFound();

            try
            {
                todo.Done = true;
                todo.CreatedAt = DateTime.Now;

                _context.Todos.Update(todo);
                _context.SaveChanges();

                var todoSummaryUpdateDto = new TodoSummaryUpdateDto
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Done = todo.Done,
                    UpdateAt = todo.UpdateAt
                };

                return Ok(todoSummaryUpdateDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return BadRequest();
            }
        }

        [HttpDelete("todos/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null) return BadRequest();

            try
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return BadRequest();
            }
        }
    }
}