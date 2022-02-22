using System.ComponentModel.DataAnnotations;

namespace RepaifPhoneDB
{
    public class Employee
    {
        [Key]
        public Guid ID_Employee { get; set; }
        public string? FIO { get; set; }
        public Guid ID_Position { get; set; }
        public Position? Position { get; set; }
        public string? Series_Number_Password { get; set; }
        public string? Address { get; set; }
        public string? Phone_Number { get; set; }
        public DateTime employmentDate;
        public DateTime? EmploymentDate
        {
            get { return employmentDate; }
            set { value = employmentDate; }
        }
        DateTime now = DateTime.Today;
        public int experience;
        public int Experience { get { return experience; }
            set { experience = now.Year - employmentDate.Year; } }

        public List<Order> Orders { get; set; } = new();


    }
}
