using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamCRUDTestWebAPI.Models;

namespace TeamCRUDTestWebAPI.Contracts
{
    public interface IPlayerStatusRepository
    {
        IEnumerable<PlayerStatuses> GettAllItms();
        Task<PlayerStatuses> Add(PlayerStatuses playerStatus);
        Task<PlayerStatuses> Update(PlayerStatuses playerStatus);
        Task<PlayerStatuses> Remove(int id);
        Task<bool> Exist(int id);
        Task<PlayerStatuses> Find(int id);
    }
}
