using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamCRUDTestWebAPI.Contracts;
using TeamCRUDTestWebAPI.Models;

namespace TeamCRUDTestWebAPI.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private TeamContext _teamContext;

        public TeamRepository(TeamContext teamContext)
        {
            _teamContext = teamContext;
        }

        public async Task<Teams> Add(Teams team)
        {
            await _teamContext.Teams.AddAsync(team);
            await _teamContext.SaveChangesAsync();
            return team;
        }

        public async Task<Teams> Find(string id)
        {
            return await _teamContext.Teams.Include(team => team.Players).FirstOrDefaultAsync(team => team.TeamId == id);
        }

        public IEnumerable<Teams> GetAll()
        {
            return _teamContext.Teams.Include(team => team.Players);
        }

        public async Task<Teams> Remove(string id)
        {
            var team = await _teamContext.Teams.SingleOrDefaultAsync(t => t.TeamId == id);
            _teamContext.Teams.Remove(team);

            foreach (var pl in _teamContext.Players)
            {
                if(pl.TeamId == id)
                {
                    pl.TeamId = null;
                }
            }

            await _teamContext.SaveChangesAsync();

            return team;
        }

        public async Task<Teams> Update(Teams team)
        {
            _teamContext.Entry(team).State = EntityState.Modified;
            await _teamContext.SaveChangesAsync();

            return team;
        }
    }
}
