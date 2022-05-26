using DivChatWEBAPI.Hubs;
using DivChatWEBAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DivChatWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class invitationsController : ControllerBase
    {
        private IUserDataService service;
        private IHubContext<MyHub> hub;
        public invitationsController(IHubContext<MyHub> hub)
        {
            service = new UserDataService();
            this.hub = hub;
        }
        [HttpPost()]
        public IActionResult invitations([Bind("from, to, server")] Connection connection)
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
                user.chats.Add(new Chat() { contact = new contact() { id = connection.from, name = connection.from, last = null, lastdate = null, server = connection.server }, messages = new List<message>() });            
                hub.Clients.All.SendAsync("FriendRequest", connection.to);
                return StatusCode(201);
            }
            return NotFound();
        }
    }
}
