﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Models
{
    public class SignUpUserModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
    }
}
