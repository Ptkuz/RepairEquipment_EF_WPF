using System.ComponentModel.DataAnnotations;

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

        string? id_employee;

        public string? ID_Employee
        {
            get { return id_employee; }
            set { id_employee = value; }
        }
        public Employee? Employee { get; set; }

        public int ID_Status { get; set; }
        public Order_Status? Order_Status { get; set; }

        public Performance? Per { get; set; }


        DateTime? date_Order;

        public DateTime? Date_Order
        {
            get { return date_Order; }
            set { date_Order = value; }
        }
    }
}
