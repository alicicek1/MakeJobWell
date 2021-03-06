﻿using MakeJobWell.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeJobWell.Service.WebAPI.Models.SelfEntities
{
    public class UserDTO
    {
        public int IDDTO { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
    }
}
