using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.Models
{
    public class vmMessage
    {
        public long Senderid { get; set; }
        public long Receiverid { get; set; }
        public string Message { get; set; }
        public string Messagestatus { get; set; }
        public DateTime Messagedate { get; set; } = DateTime.Now;
    }
}
