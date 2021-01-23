using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SignalRServer.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.data.chat
{
    public class ChatDBService : IChatDBService
    {
        private SignalRChatContext dbContext = null;

        public async Task<bool> DeleteChatFor(long chatId, long deleteFor)
        {
            bool success = false;

            try
            {
                using (dbContext = new SignalRChatContext())
                {
                    UserChat userChat = await(from x in dbContext.UserChat
                                              where x.Chatid == chatId
                                              select x).FirstOrDefaultAsync();

                    if (userChat != null && (userChat.Deletedfor > 0 || deleteFor < 0))
                    {
                        dbContext.Remove(userChat);
                    }
                    else
                    {
                        userChat.Deletedfor = deleteFor;
                        dbContext.Update(userChat);
                    }

                    await dbContext.SaveChangesAsync();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return success;
        }

        public Task<int> DeleteItemAsync(UserChat item)
        {
            throw new NotImplementedException();
        }

        public List<UserChat> GetChatHistoryOfUser(long userId, long contactId)
        {
            List<UserChat> userChat = null;
            try
            {
                using (dbContext = new SignalRChatContext())
                {
                    userChat = (from x in dbContext.UserChat
                                where (((x.Senderid == userId && x.Receiverid == contactId) || (x.Receiverid == userId && x.Senderid == contactId)) && x.Deletedfor != userId)
                                select x).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                userChat = null;
            }

            return userChat;
        }

        public Task<UserChat> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserChat>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserChat> SaveItemAsync(UserChat item)
        {
            try
            {
                using (dbContext = new SignalRChatContext())
                {
                    EntityEntry<UserChat> newItem = dbContext.UserChat.Add(item);
                    await dbContext.SaveChangesAsync();

                    return newItem.Entity;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
