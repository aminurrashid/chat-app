using SignalRServer.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer.data
{
    public interface IDatabaseService<T>
    {
        Task<List<T>> GetItemsAsync();
        Task<T> GetItemAsync(int id);
        Task<T> SaveItemAsync(T item);
        Task<int> DeleteItemAsync(T item);
    }
}
