using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRServer.data;
using SignalRServer.data.chat;
using SignalRServer.Models.EntityModels;

namespace SignalRServer.api.chat
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IChatDBService _chatDBService;

        public ChatController(IChatDBService chatDBService)
        {
            _chatDBService = chatDBService;
        }


        //GET: api/chat/userChat
        [HttpGet("[action]")]
        public async Task<object> UserChat([FromQuery]string param)
        {
            object result = null;

            try
            {
                if (param != string.Empty)
                {
                    dynamic data = JsonConvert.DeserializeObject(param);
                    UserChat model = JsonConvert.DeserializeObject<UserChat>(data.ToString());
                    if (model != null)
                    {
                        result = _chatDBService.GetChatHistoryOfUser(model.Senderid, model.Receiverid);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result;
        }

        //GET: api/chat/deletechat
        [HttpDelete("[action]")]
        public async Task<bool> DeleteChat([FromQuery] long chatId, [FromQuery] long deleteFor)
        {
            bool success = false;

            try
            {
                success = await _chatDBService.DeleteChatFor(chatId, deleteFor);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return success;
        }
    }
}