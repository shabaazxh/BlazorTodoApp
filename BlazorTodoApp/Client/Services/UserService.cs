using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using BlazorTodoApp.Shared;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlazorTodoApp.Client.Services
{
    public class UserService : IUserService
    {

        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<User> LogUserIn([FromBody] string username, [FromBody] string password)
        {
            var result = await _http.PostAsJsonAsync<User>("User");
            return result;
        }

        public async Task<User> RegisterUser(User addUser)
        {
            var result = await _http.PostAsJsonAsync("User", addUser);
            return await result.Content.ReadFromJsonAsync<User>();
        }
    }
}