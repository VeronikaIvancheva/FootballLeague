using Microsoft.AspNetCore.Identity;
using FootballLeague.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Data.Entities
{
    public class User : IdentityUser
    {
        public UserRoles Role { get; set; }
    }
}
