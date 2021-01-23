using SignalRServer.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.data.user
{
    public interface IUserDBService : IDatabaseService<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
