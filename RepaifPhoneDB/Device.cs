using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepaifPhoneDB
{
    public class Device
    {
        [Key]
        public Guid ID_Device { get; set; }
        public string? Name { get; set; }
        public string? Serial_Number { get; set; }
        public string? Description { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public List<Order> Orders { get; set; } = new();

    }
}
