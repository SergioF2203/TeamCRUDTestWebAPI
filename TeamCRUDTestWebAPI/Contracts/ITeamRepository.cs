using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamCRUDTestWebAPI.Models;

namespace TeamCRUDTestWebAPI.Contracts
{
    public interface ITeamRepository
    {
        Task<Teams> Add(Teams team);
        IEnumerable<Teams> GetAll();
        Task<Teams> Find(string id);
        Task<Teams> Remove(string id);
        Task<Teams> Update(Teams team);
    }
}
