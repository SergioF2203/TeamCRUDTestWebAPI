using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamCRUDTestWebAPI.Models;

namespace TeamCRUDTestWebAPI.Contracts
{
    public interface IPlayerRepository
    {
        Task<Players> Add(Players player);
        IEnumerable<Players> GetAll();
        Task<Players> GetItem(string id);
        Task<Players> Remove(string id);
        Task<Players> Update(Players player);
    }
}
