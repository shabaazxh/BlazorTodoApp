
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorTodoApp.Server.Data;
using BlazorTodoApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BlazorTodoApp.Server.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    

    public class TodoItemsController : ControllerBase
    {
        private readonly DataContext context;

/*        public List<TodoItem> todoPosts { get; set; } = new List<TodoItem>()
        {
*//*            new TodoItem {Id = 1, Title = "number 11:",  isDone = false},
            new TodoItem {Id = 2, Title = "number 21:",  isDone = false}*//*
        };*/

        public TodoItemsController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> SingleTodoItem(Guid id)
        {
            Console.WriteLine("CONTROLLER: " + id);

            var content = context.TodoItems.Find(id);
            var post = context.TodoItems.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound("This post does not exist / could not find when getting from controller");
            }

            return Ok(post);
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> Get()
        {

            return Ok(context.TodoItems);
        }

        [HttpPost]
        public async Task <ActionResult<TodoItem>> CreateNewTodoItem(TodoItem item)
        {
            context.Add(item);
            await context.SaveChangesAsync();

            return item;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItem>> Update(Guid id,TodoItem item)
        {
            context.TodoItems.Update(item);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<TodoItem>> Delete(Guid id)
        {
            var todoItem = context.TodoItems.FirstOrDefault(c => c.Id == id);
            context.TodoItems.Remove(todoItem);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}