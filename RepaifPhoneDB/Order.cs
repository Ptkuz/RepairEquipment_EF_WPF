using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepaifPhoneDB
{
    public class Order
    {
        [Key]
        public Guid ID_Order { get; set; }

        public Guid ID_Device { get; set; }
        public Device? Device { get; set; }

        public Guid ID_Client { get; set; }
        public Client? Client { get; set; }

        public Guid ID_Employee { get; set; }
        public Employee? Employee { get; set; }

        public Guid ID_Status { get; set; }
        public Order_Status? Order_Status { get; set; }

        public Guid ID_Performance { get; set; }
        public Performance? Performance { get; set; }


        public DateTime? Date_Order { get; set; }
    }
}
