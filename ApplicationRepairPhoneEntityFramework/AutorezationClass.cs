﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRepairPhoneEntityFramework
{
    public class AutorezationClass
    {
        public string? Login { get; set; }
        public string? Password { get; set; }

        public AutorezationClass(string login, string password) 
        {
            Login = login;
            Password = password;



        }


    }
}
