﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceriesStore.Models
{
    public class LoginModel
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
