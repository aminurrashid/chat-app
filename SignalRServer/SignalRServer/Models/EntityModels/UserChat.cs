using System;
using System.Collections.Generic;

namespace SignalRServer.Models.EntityModels
{
    public partial class UserChat
    {
        public long Chatid { get; set; }
        public long Senderid { get; set; }
        public long Receiverid { get; set; }
        public string Message { get; set; }
        public DateTime? Messagedate { get; set; }
        public long? Deletedfor { get; set; }
    }
}
