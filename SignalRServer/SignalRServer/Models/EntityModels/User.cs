using System;
using System.Collections.Generic;

namespace SignalRServer.Models.EntityModels
{
    public partial class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
