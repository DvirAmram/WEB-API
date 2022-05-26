using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DivChatWEBAPI.Models;

namespace DivChatWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserDataService service;

        public UsersController()
        {
            service = new UserDataService();
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            //User user = service.Get(UserDataService.connected);
            User user = service.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // create new user = register
        [HttpPost("signUp")]
        public IActionResult signUp(string username, string nickname, string password)
        {
            User user = new User() { Username = username, Nickname = nickname, Password = password, SrcImg= "none", chats = new List<Chat>() };
            if (service.GetAll().Select(o => o.Username).Contains(user.Username))
            {
                return BadRequest();
            }
            service.Create(user);
            return Ok(user);
        }
        [HttpGet("chats/{id}")]
        public IActionResult GetChat(string id)
        {
            User user = service.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.chats);
        }

        [HttpPost("login/{user_name}/{password}")]
        public IActionResult login(string user_name, string password)
        {
            User user = service.GetAll().Where(o => o.Username == user_name).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            if (user.Password != password)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
