using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepaifPhoneDB
{
    public class Position
    {
        [Key]
        public int ID_Position { get; set; }
        public string? Name_Position { get; set; }
        public List<Employee>? Employees { get; set; } = new();



    }
}
