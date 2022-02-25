using System.ComponentModel.DataAnnotations;

namespace RepaifPhoneDB
{
    public class Employee
    {
        [Key]
        public string? ID_Employee { get; set; }

        string? password;
        public string? Password
        {
            get { return password; }
            set { password = value; }
        }

        string? fio;
        public string? FIO
        {
            get { return fio; }
            set { fio = value; }
        }
        public int ID_Position { get; set; }
        public Position? Position { get; set; }

        string? series_number;
        public string? Series_Number_Password
        {
            get { return series_number; }
            set { series_number = value; }
        }

        string? address;
        public string? Address
        {
            get { return address; }
            set { address = value; }
        }
        string? phone_number;
        public string? Phone_Number
        {
            get { return phone_number; }
            set { phone_number = value; }
        }
        DateTime? employmentDate;
        public DateTime? EmploymentDate
        {
            get { return employmentDate; }
            set { employmentDate = value; }
        }


        public List<Order> Orders { get; set; } = new();


    }
}
