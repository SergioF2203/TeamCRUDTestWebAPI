using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamCRUDTestWebAPI.Models;

namespace TeamCRUDTestWebAPI
{
    public class StartData
    {
        public static void Initialize(TeamContext context)
        {
            if (!context.TeamStates.Any())
            {
                context.TeamStates.AddRange(
                    new TeamStates
                    {
                        TeamStateTitle = "pending"
                    },
                    new TeamStates
                    {
                        TeamStateTitle = "filled"
                    },
                    new TeamStates
                    {
                        TeamStateTitle = "active"
                    }
                    );
            }
            if (!context.PlayerStatuses.Any())
            {
                context.PlayerStatuses.AddRange(
                    new PlayerStatuses
                    {
                        PlayerStatusTitle = "online"
                    },
                    new PlayerStatuses
                    {
                        PlayerStatusTitle = "offline"
                    },
                    new PlayerStatuses
                    {
                        PlayerStatusTitle = "blocked"
                    }
                    );
            }
            context.SaveChangesAsync();
        }
    }
}
