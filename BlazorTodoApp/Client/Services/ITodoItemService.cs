
using BlazorTodoApp.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorTodoApp.Client.Services
{
    interface ITodoItemService
    {
        Task<List<TodoItem>> GetAllItems();
        Task<TodoItem> GetSingleTodoItem(Guid id);
        Task<TodoItem> CreateNewToDoItem(TodoItem item);
        Task<TodoItem> UpdateToDoItem(Guid id, TodoItem item);

        Task<TodoItem> DeleteToDoItem(Guid id);
    }
}
