using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeamCRUDTestWebAPI.Models
{
    public class TeamStates
    {
        [Key]
        public int TeamStateId { get; set; }

        [StringLength(50)]
        public string TeamStateTitle { get; set; }

    }
}
