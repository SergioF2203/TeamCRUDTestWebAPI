using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeamCRUDTestWebAPI.Models
{
    public class Players
    {

        [Key]
        [StringLength(50)]
        
        public string PlayerId { get; set; }

        [StringLength(50)]
        public string PlayerName { get; set; }

        public int PlayerStatusId { get; set; }

        [StringLength(50)]
        public string TeamId { get; set; }



    }
}
