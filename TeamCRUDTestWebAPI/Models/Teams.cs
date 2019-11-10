using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamCRUDTestWebAPI.Models
{
    public class Teams
    {

        public Teams()
        {
            Players = new HashSet<Players>();
        }

        [Key]
        [StringLength(50)]
        public string TeamId { get; set; }

        [StringLength(50)]
        public string TeamTitle { get; set; }

        public int TeamStateId { get; set; }

        public DateTime? DateTimeCreated { get; set; }


        public virtual ICollection<Players> Players { get; set; }


    }
}
