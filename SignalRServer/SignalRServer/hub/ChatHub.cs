using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SignalRServer.data;
using SignalRServer.data.chat;
using SignalRServer.data.user;
using SignalRServer.Models;
using SignalRServer.Models.EntityModels;

namespace SignalRServer.hub
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<long> _connections = new ConnectionMapping<long>();
        private static List<User> connectedUsers = new List<User>();
        private IUserDBService _userDBService;
        private IChatDBService _chatDBService;
        private JsonSerializerSettings camelSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

        public ChatHub(IUserDBService userDBService, IChatDBService chatDBService)
        {
            _userDBService = userDBService;
            _chatDBService = chatDBService;
        }

        public async Task<long> SendMessage(vmMessage message)
        {
            long chatId = 0;
            //Receive Message
            List<string> ReceiverConnectionids = _connections.GetConnections(message.Receiverid).ToList<string>();
            if (ReceiverConnectionids.Count() > 0)
            {
                //Save-Receive-Message
                try
                {
                    UserChat model = new UserChat()
                    {
                        Senderid = message.Senderid,
                        Receiverid = message.Receiverid,
                        Message = message.Message,
                        Messagedate = message.Messagedate
                    };

                    UserChat userChat = await _chatDBService.SaveItemAsync(model);
                    chatId = userChat.Chatid;

                    await Clients.Clients(ReceiverConnectionids).SendAsync("ReceiveMessage", message);
                }
                catch (Exception) { }
            }

            return chatId;
        }


        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                try
                {
                    //Add Logged User
                    int userId = int.Parse(httpContext.Request.Query["userId"].ToString());
                    if (userId > 0)
                    {
                        User user = await _userDBService.GetItemAsync(userId);
                        if (user != null)
                        {
                            var connId = Context.ConnectionId.ToString();
                            _connections.Add(userId, connId);

                            if (!connectedUsers.Any(x => x != null && x.Id == userId))
                            {
                                connectedUsers.Add(user);
                            }

                            //Update Client
                            string usersJson = JsonConvert.SerializeObject(connectedUsers, camelSettings);
                            await Clients.All.SendAsync("UpdateUserList", usersJson);
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                try
                {
                    //Remove Logged User
                    var userId = int.Parse(httpContext.Request.Query["userId"].ToString());
                    _connections.Remove(userId, Context.ConnectionId);

                    connectedUsers.RemoveAll(x => x.Id == userId);

                    //Update Client
                    //await Clients.All.SendAsync("UpdateUserList", _connections.ToJson());
                    string usersJson = JsonConvert.SerializeObject(connectedUsers, camelSettings);
                    await Clients.All.SendAsync("UpdateUserList", usersJson);
                }
                catch (Exception) { }
            }

            //return base.OnDisconnectedAsync(exception);
        }
    }
}
