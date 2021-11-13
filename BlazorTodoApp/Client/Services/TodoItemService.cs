using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using BlazorTodoApp.Shared;
using System.Threading.Tasks;

namespace BlazorTodoApp.Client.Services
{
    public class TodoItemService : ITodoItemService
    {

        private readonly HttpClient _http;

        public TodoItemService(HttpClient http)
        {
            _http = http;
        }

        public async Task<TodoItem> CreateNewToDoItem(TodoItem item)
        {
            var result = await _http.PostAsJsonAsync("TodoItems", item);
            return await result.Content.ReadFromJsonAsync<TodoItem>();
        }

        public async Task<TodoItem> DeleteToDoItem(Guid id)
        {
            Console.WriteLine("GOT PASSED: " + id);
            HttpResponseMessage response = await _http.DeleteAsync($"TodoItems/{id}");
            return response.Content.ReadFromJsonAsync<TodoItem>().Result;
        }

        public async Task<List<TodoItem>> GetAllItems()
        {
            return await _http.GetFromJsonAsync<List<TodoItem>>("TodoItems");
        }

        public async Task<TodoItem> GetSingleTodoItem(Guid id)
        {
            var result = await _http.GetFromJsonAsync<TodoItem>($"TodoItems/{id}");
            return result;
           /* if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new TodoItem { Title = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<TodoItem>();
            }*/

        }

        public async Task<TodoItem> UpdateToDoItem(Guid id, TodoItem item)
        {
            HttpResponseMessage response = await _http.PutAsJsonAsync("TodoItems/{id}", item);
            return response.Content.ReadFromJsonAsync<TodoItem>().Result;
            
        }
    }
}