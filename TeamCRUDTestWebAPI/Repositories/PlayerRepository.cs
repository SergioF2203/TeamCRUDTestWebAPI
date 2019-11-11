using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamCRUDTestWebAPI.Contracts;
using TeamCRUDTestWebAPI.Models;

namespace TeamCRUDTestWebAPI.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private TeamContext _teamContext;

        public PlayerRepository(TeamContext teamContext)
        {
            _teamContext = teamContext;
        }

        public async Task<Players> Add(Players player)
        {
            await _teamContext.Players.AddAsync(player);
            await _teamContext.SaveChangesAsync();
            return player;
        }

        public IEnumerable<Players> GetAll()
        {
            return _teamContext.Players;
        }

        public async Task<Players> GetItem(string id)
        {
            return await _teamContext.Players.SingleOrDefaultAsync(p => p.PlayerId == id);
        }

        public async Task<Players> Remove(string id)
        {
            var player = await _teamContext.Players.SingleOrDefaultAsync(p => p.PlayerId == id);
            _teamContext.Remove(player);
            await _teamContext.SaveChangesAsync();
            return player;
        }

        public async Task<Players> Update(Players player)
        {
            _teamContext.Entry(player).State = EntityState.Modified;
            await _teamContext.SaveChangesAsync();
            return player;
        }
    }
}
