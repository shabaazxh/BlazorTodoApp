
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

    public class UserController : ControllerBase
    {
        private readonly UserDataContext context;

        public UserController(UserDataContext context)
        {
            this.context = context;
        }

/*        [HttpGet]
        public ActionResult<User> LoginUserAccount(User account)
        {
            var username = context.User.Find(account.Username);
            var password = username.Password;

            
        }*/

        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser(User addUser)
        {
            context.Add(addUser);
            await context.SaveChangesAsync();
            return addUser;
        }

    }
}