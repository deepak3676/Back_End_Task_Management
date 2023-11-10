using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class taskStruct
    {
        [Key]
        public int Id { get; set; }
        public string taskName { get; set; }
        public string taskDescription { get; set; }
 
        public DateTime taskStartTime { get; set; }

        public DateTime taskEndTime { get; set; }
        public int userId { get; set; }


    }
}
