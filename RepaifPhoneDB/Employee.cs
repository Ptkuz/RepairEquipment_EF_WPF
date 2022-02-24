using System.ComponentModel.DataAnnotations;

namespace RepaifPhoneDB
{
    public class Employee
    {
        [Key]
        public string? ID_Employee { get; set; }
        public string? Password { get; set; }
        public string? FIO { get; set; }
        public int ID_Position { get; set; }
        public Position? Position { get; set; }
        public string? Series_Number_Password { get; set; }
        public string? Address { get; set; }
        public string? Phone_Number { get; set; }
        public DateTime employmentDate;
        public DateTime? EmploymentDate { get; set; }


        public List<Order> Orders { get; set; } = new();


    }
}
