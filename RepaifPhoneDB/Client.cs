﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepaifPhoneDB
{
    public class Client
    {
        [Key]
        public Guid ID_Client { get; set; }
        public string? FIO { get; set; }
        public string? Address { get; set; }
        public string? Phone_Number { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}