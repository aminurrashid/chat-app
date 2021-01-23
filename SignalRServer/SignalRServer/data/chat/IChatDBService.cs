using SignalRServer.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.data.chat
{
    public interface IChatDBService : IDatabaseService<UserChat>
    {
        List<UserChat> GetChatHistoryOfUser(long userId, long contactId);
        Task<bool> DeleteChatFor(long chatId, long deleteFor);
    }
}
