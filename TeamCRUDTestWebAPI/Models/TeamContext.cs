using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TeamCRUDTestWebAPI.Models
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<PlayerStatuses> PlayerStatuses { get; set; }
        public DbSet<TeamStates> TeamStates { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Players> Players { get; set; }


    }
}
