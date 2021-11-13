
using BlazorTodoApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorTodoApp.Client.Services
{
    interface IUserService
    {
        Task<User> LogUserIn([FromBody] string username, [FromBody] string password);
        Task<User> RegisterUser(User addUser);
    }
}
