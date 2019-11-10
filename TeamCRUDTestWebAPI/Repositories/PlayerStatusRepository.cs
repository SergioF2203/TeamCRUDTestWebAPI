using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamCRUDTestWebAPI.Contracts;
using TeamCRUDTestWebAPI.Models;

namespace TeamCRUDTestWebAPI.Repositories
{
    public class PlayerStatusRepository : IPlayerStatusRepository
    {
        private TeamContext _teamContext;

        public PlayerStatusRepository(TeamContext teamContext)
        {
            _teamContext = teamContext;
        }
        public async Task<PlayerStatuses> Add(PlayerStatuses playerStatus)
        {
            await _teamContext.PlayerStatuses.AddAsync(playerStatus);
            await _teamContext.SaveChangesAsync();
            return playerStatus;
        }

        public async Task<PlayerStatuses> Find(int id)
        {
            return await _teamContext.PlayerStatuses.SingleOrDefaultAsync(m => m.PlayerStatusId == id);
        }

        public async Task<bool> Exist(int id)
        {
            return await _teamContext.PlayerStatuses.AnyAsync(p => p.PlayerStatusId == id);
        }

        public IEnumerable<PlayerStatuses> GettAllItms()
        {
            return _teamContext.PlayerStatuses;
        }

        public async Task<PlayerStatuses> Remove(int id)
        {
            var playerStatus = await _teamContext.PlayerStatuses.SingleOrDefaultAsync(p => p.PlayerStatusId == id);
            _teamContext.PlayerStatuses.Remove(playerStatus);
            await _teamContext.SaveChangesAsync();
            return playerStatus;
        }

        public async Task<PlayerStatuses> Update(PlayerStatuses playerStatus)
        {
            _teamContext.Entry(playerStatus).State = EntityState.Modified;
            await _teamContext.SaveChangesAsync();
            return playerStatus;
        }
    }
}
