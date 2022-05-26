using DivChatWEBAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DivChatWEBAPI.Controllers
{
    [Route("api/contacts/{contactname}/[controller]")]
    [ApiController]
    public class messagesController : ControllerBase
    {
        private IUserDataService service;
        public messagesController()
        {
            service = new UserDataService();
        }
        // GET: api/<messagesController>
        [HttpGet]
        public IActionResult Get(string connecteduser, string contactname)
        {
            //User user = service.Get(UserDataService.connected);
            User user = service.Get(connecteduser);
            if (user == null) return NotFound();
            List<message> messages = user.chats.Where(x => x.contact.id == contactname).FirstOrDefault().messages;

            return Ok(messages);
        }

        // GET api/<messagesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string connecteduser, string contactname,int id)
        {
            //User user = service.Get(UserDataService.connected);
            User user = service.Get(connecteduser);
            if (user == null) return NotFound();
            List<message> messages = user.chats.Where(x => x.contact.id == contactname).FirstOrDefault().messages;
            message mess = messages.Where(x => x.id == id).FirstOrDefault();
            if (mess == null) return NotFound();
            return Ok(mess);
        }

        // POST api/<messagesController>
        [HttpPost]
        public IActionResult Post([Bind("connecteduser,contactname,content")] MessageSend contact)
        {
            //User user = service.Get(UserDataService.connected);
            User user = service.Get(contact.connecteduser);
            if (user == null) return NotFound();
            List<message> messages = user.chats.Where(x => x.contact.id == contact.contactname).FirstOrDefault().messages;
            int id;
            if (messages.Count == 0)
            {
                id = 0;
            }
            else
            {
                id = messages.Max(x => x.id) + 1;
            }
            message mess = new message() { id = id, content = contact.content, created = DateTime.Now, sent = true };
            messages.Add(mess);
            user.chats.Where(x => x.contact.id == contact.contactname).FirstOrDefault().contact.lastdate = mess.created;
            user.chats.Where(x => x.contact.id == contact.contactname).FirstOrDefault().contact.last = mess.content;
            return StatusCode(201);
        }

        // PUT api/<messagesController>/5
        [HttpPut("{id}")]
        public IActionResult Put([Bind("connecteduser, contactname, id,content")] MessageSend contact)
        {
            //User user = service.Get(UserDataService.connected);
            User user = service.Get(contact.connecteduser);
            if (user == null) return NotFound();
            List<message> messages = user.chats.Where(x => x.contact.id == contact.contactname).FirstOrDefault().messages;
            message mess = messages.Where(x => x.id == contact.id).FirstOrDefault();
            if (mess == null) return NotFound();
            mess.content = contact.content;
            return NoContent();
        }

        // DELETE api/<messagesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string connecteduser, string contactname, int id)
        {
            //User user = service.Get(UserDataService.connected);
            User user = service.Get(connecteduser);
            if (user == null) return NotFound();
            List<message> messages = user.chats.Where(x => x.contact.id == contactname).FirstOrDefault().messages;
            message mess = messages.Where(x => x.id == id).FirstOrDefault();
            if (mess == null) return NotFound();
            messages.Remove(mess);
            return NoContent();
        }
    }
}
