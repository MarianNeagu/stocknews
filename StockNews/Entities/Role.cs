﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StockNews.Entities
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
