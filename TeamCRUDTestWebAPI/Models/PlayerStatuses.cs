using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeamCRUDTestWebAPI.Models
{
    public class PlayerStatuses
    {

        [Key]
        public int PlayerStatusId { get; set; }

        [StringLength(10)]
        public string PlayerStatusTitle { get; set; }


    }
}
