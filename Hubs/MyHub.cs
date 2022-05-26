using DivChatWEBAPI.Models;
using Microsoft.AspNetCore.SignalR;

namespace DivChatWEBAPI.Hubs
{
    public class MyHub : Hub
    {
        //private IUserDataService service;

        //public MyHub(IUserDataService service)
        //{
        //    this.service = service;
        //}

        public async Task sendMessage(string dst)
        {
            // All - all the clients - we need to change it
            // "ChangeRecived" - the function that called
            await Clients.All.SendAsync("RecievedMessage",dst);
        }

        public async Task addNewUser(string dst)
        {
            // All - all the clients - we need to change it
            // "ChangeRecived" - the function that called
            await Clients.All.SendAsync("FriendRequest", dst);
        }
    }
}
