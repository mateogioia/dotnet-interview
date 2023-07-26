using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers;

//localhost:xxx/api/todoList/1/todoItems

[Route("api/todoLists")]
public class TodoItemsController : ControllerBase
{
    private readonly TodoContext _context;

    public TodoItemsController(TodoContext context)
    {
        _context = context;
    }
    
    //GET: api/todoLists/1/todoItems
    [HttpGet("{id}/todoItems")]
    public async Task<ActionResult<IList<TodoItem>>> GetTodoItems(long id)
    {
        if (_context.TodoList == null)
        {
            return NotFound();
        }

        var todoList = _context.TodoList.Include("items").Where(list => list.Id == id).FirstOrDefault();

        if (todoList == null)
        {
            return NotFound();
        }

        return Ok(todoList.items.ToList());
    }
    
    //GET: api/todoLists/1/todoItems/1
    [HttpGet("{id}/todoItems/{itemId}")]
    public async Task<ActionResult<IList<TodoItem>>> GetTodoItem(long id, long itemId)
    {
        if (_context.TodoList == null)
        {
            return NotFound();
        }

        //var todoItem = _context.TodoItems.Where(item => item.listId == id && item.Id == itemId);

        return Ok();
    }
}