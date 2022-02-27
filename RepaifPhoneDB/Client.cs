using System.ComponentModel.DataAnnotations;

namespace RepaifPhoneDB
{
    public class Client
    {
        [Key]
        public Guid ID_Client { get; set; }
        string? fio;
        public string? FIO
        {
            get { return fio; }
            set { fio = value; }
        }

        string? series_number;
        public string? Series_Number_Passport
        {
            get { return series_number; }
            set { series_number = value; }
        }

        string? phone_number;
        public string? Phone_Number
        {
            get { return phone_number; }
            set { phone_number = value; }
        }
        public string? Email { get; set; }

        DateTime? dateAdded;
        public DateTime? DateAdded
        {
            get { return dateAdded; }
            set { dateAdded = value; }
        }

        public List<Order> Orders { get; set; } = new();
    }
}
