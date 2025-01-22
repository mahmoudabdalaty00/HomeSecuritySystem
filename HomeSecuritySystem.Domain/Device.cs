using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSecuritySystem.Domain
{
    public  class Device
    {
        [Key]
        public int Id { get; set; } 
       
        public string DeviceType { get; set; }
      
        public string Model { get; set; }
       
        public bool Status { get; set; }
       
        public int UserId { get; set; }
 
    }
}
