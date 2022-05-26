using DivChatWEBAPI.Hubs;
using DivChatWEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DivChatWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class transferController : ControllerBase
    {
        private IUserDataService service;
        private IHubContext<MyHub> hub;
        public transferController(IHubContext<MyHub> hub)
        {
            this.service = new UserDataService();
            this.hub = hub; 
        }
        [HttpPost()]
        public IActionResult transfer([Bind("from, to, content")] Connection connection)
        {
            //User user = service.Get(UserDataService.connected);
            User user = service.Get(connection.to);
            if (user == null)
            {
                return NotFound();
            }
            Chat chat = user.chats.Where(x => x.contact.id == connection.from).FirstOrDefault();
            if (chat == null)
            {
                return NotFound();
            }
            int id;
            if (chat.messages.Count == 0)
            {
                id = 0;
            }
            else
            {
                id = chat.messages.Max(x => x.id) + 1;
            }
            chat.messages.Add(new message() {id = id , content = connection.content , created = DateTime.Now, sent = false});
            chat.contact.last = connection.content;
            chat.contact.lastdate = DateTime.Now;
            hub.Clients.All.SendAsync("RecievedMessage", connection.to);
            return StatusCode(201);
        }


    }
}
