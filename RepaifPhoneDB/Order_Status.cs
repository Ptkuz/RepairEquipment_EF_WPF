using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepaifPhoneDB
{
    public class Order_Status
    {
        [Key]
        public int ID_Status { get; set; }
        public string? Name_Status { get; set; }

        public List<Order> Orders { get; set; } = new();




    }
}
