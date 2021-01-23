using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SignalRServer.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.data.user
{
    public class UserDBService : IUserDBService
    {
        private SignalRChatContext dbContext = null;
        public Task<int> DeleteItemAsync(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetItemAsync(int id)
        {
            User user = null;
            try
            {
                using (dbContext = new SignalRChatContext())
                {
                    user = await(from x in dbContext.User
                                 where x.Id == id
                                 select x).FirstOrDefaultAsync();
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
                user = null;
            }

            return user;
        }

        public Task<List<User>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            User user = null;
            try
            {
                using (dbContext = new SignalRChatContext())
                {
                    user = await(from x in dbContext.User
                                       where x.Email == email
                                       select x).FirstOrDefaultAsync();
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
                user = null;
            }

            return user;
        }

        public async Task<User> SaveItemAsync(User item)
        {
            try
            {
                using (dbContext = new SignalRChatContext())
                {
                    EntityEntry<User> newItem = dbContext.User.Add(item);
                    await dbContext.SaveChangesAsync();

                    return newItem.Entity;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }

            return null;
        }
    }
}
