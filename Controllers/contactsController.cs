using DivChatWEBAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DivChatWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class contactsController : ControllerBase
    {
        private IUserDataService service;
        public contactsController()
        {
            service = new UserDataService();
        }
        // GET: api/<ContactsController>
        [HttpGet]
        public IActionResult Get(string connecteduser)
        {
            //User user = service.Get(UserDataService.connected);

            User user = service.Get(connecteduser);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.chats.Select(o => o.contact));
        }
        [HttpGet("{id}/{connecteduser}")]
        public IActionResult GetChat(string connecteduser, string id)
        {
            User user = service.Get(connecteduser);
            if (user == null)
            {
                return NotFound();
            }
            contact contact = user.chats.Select(o => o.contact).Where(x => x.id == id).FirstOrDefault();
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(user.chats.Where(x => x.contact.id == id).FirstOrDefault());
        }
        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string connecteduser,string id)
        {
            //User user = service.Get(UserDataService.connected);
            User user = service.Get(connecteduser);
            if (user == null)
            {
                return NotFound();
            }
            contact contact = user.chats.Select(o => o.contact).Where(x => x.id == id).FirstOrDefault();
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // POST api/<ContactsController>
        [HttpPost]
        public IActionResult Post([Bind("connecteduser, id, name,server")] ConnectedUser connect)
        {
            //User user = service.Get(UserDataService.connected);
            User user = service.Get(connect.connecteduser);
            if (user == null)
            {
                return NotFound();
            }
            contact contact = user.chats.Select(o => o.contact).Where(x => x.id == connect.id && x.server == connect.server).FirstOrDefault();
            if (contact == null)
            {
                user.chats.Add(new Chat() {contact = new contact()
                {
                    id = connect.id,
                    name = connect.name,
                    server = connect.server,
                    last = null,
                    lastdate = null
                },messages = new List <message>()});
                return StatusCode(201);
            }
            else
                return NotFound();
        }
        // POST api/<ContactsController>
        [HttpPost("Adduser")]
        public IActionResult Adduser([Bind("connecteduser, id, name,server")] ConnectedUser connect)
        {
            //User user = service.Get(UserDataService.connected);
            User user = service.Get(connect.connecteduser);
            if (user == null)
            {
                return NotFound();
            }
            if (connect.server == "localhost:7261" && service.Get(connect.id) == null)
            {
                return BadRequest();
            }
            contact contact = user.chats.Select(o => o.contact).Where(x => x.id == connect.id && x.server == connect.server).FirstOrDefault();
            if (contact == null)
            {
                user.chats.Add(new Chat()
                {
                    contact = new contact()
                    {
                        id = connect.id,
                        name = connect.name,
                        server = connect.server,
                        last = null,
                        lastdate = null
                    },
                    messages = new List<message>()
                });
                return Ok(user.chats);
            }
            else
                return NotFound();
        }
        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public IActionResult Put([Bind("connecteduser, id, name,server")] ConnectedUser connect)
        {
            //User user = service.Get(UserDataService.connected);
            User user = service.Get(connect.connecteduser);
            if (user == null)
            {
                return NotFound();
            }
            contact contact = user.chats.Select(o => o.contact).Where(x => x.id == connect.id).FirstOrDefault();
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                contact.name = connect.name;
                contact.server = connect.server;
                return NoContent();
            }
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string connecteduser,string id)
        {
            //User user = service.Get(UserDataService.connected);
            User user = service.Get(connecteduser);
            if (user == null)
            {
                return NotFound();
            }
            contact contact = user.chats.Select(o => o.contact).Where(x => x.id == id).FirstOrDefault();
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                user.chats.Remove(user.chats.Where(x => contact == x.contact).FirstOrDefault());
                return NoContent();
            }
        }

     
    }
}
