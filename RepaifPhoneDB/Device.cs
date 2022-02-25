using System.ComponentModel.DataAnnotations;

namespace RepaifPhoneDB
{
    public class Device
    {
        [Key]
        public Guid ID_Device { get; set; }

        string? name;
        public string? Name
        {
            get { return name; }
            set { name = value; }
        }

        string? serial_number;
        public string? Serial_Number
        {
            get { return serial_number; }
            set { serial_number = value; }
        }

        string? descriprion;
        public string? Description
        {
            get { return descriprion; }
            set { descriprion = value; }
        }

        string? manufacturer;
        public string? Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        string? model;
        public string? Model
        {
            get { return model; }
            set { model = value; }
        }

        DateTime? dateAdded;
        public DateTime? DateAdded
        {
            get { return dateAdded; }
            set { dateAdded = value; }
        }
        public List<Order> Orders { get; set; } = new();

    }
}
