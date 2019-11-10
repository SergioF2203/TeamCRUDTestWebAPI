using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamCRUDTestWebAPI.Contracts;
using TeamCRUDTestWebAPI.Models;

namespace TeamCRUDTestWebAPI.Repositories
{
    public class TeamStateRepository : ITeamStateRepository
    {
        private TeamContext _teamContext;

        public TeamStateRepository(TeamContext teamContext)
        {
            _teamContext = teamContext;
        }
        public async Task<TeamStates> Add(TeamStates teamState)
        {
            await _teamContext.TeamStates.AddAsync(teamState);
            await _teamContext.SaveChangesAsync();
            return teamState;
        }

        public async Task<TeamStates> Find(int id)
        {
            return await _teamContext.TeamStates.SingleOrDefaultAsync(m => m.TeamStateId == id);
        }

        public async Task<bool> Exist(int id)
        {
            return await _teamContext.TeamStates.AnyAsync(p => p.TeamStateId == id);
        }

        public IEnumerable<TeamStates> GettAllItms()
        {
            return _teamContext.TeamStates;
        }

        public async Task<TeamStates> Remove(int id)
        {
            var teamState = await _teamContext.TeamStates.SingleOrDefaultAsync(p => p.TeamStateId == id);
            _teamContext.TeamStates.Remove(teamState);
            await _teamContext.SaveChangesAsync();
            return teamState;
        }

        public async Task<TeamStates> Update(TeamStates teamState)
        {
            _teamContext.Entry(teamState).State = EntityState.Modified;
            await _teamContext.SaveChangesAsync();
            return teamState;
        }
    }
}
