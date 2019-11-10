using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamCRUDTestWebAPI.Models;

namespace TeamCRUDTestWebAPI.Contracts
{
    public interface ITeamStateRepository
    {
        IEnumerable<TeamStates> GettAllItms();
        Task<TeamStates> Add(TeamStates teamStates);
        Task<TeamStates> Update(TeamStates teamStates);
        Task<TeamStates> Remove(int id);
        Task<bool> Exist(int id);
        Task<TeamStates> Find(int id);
    }
}
