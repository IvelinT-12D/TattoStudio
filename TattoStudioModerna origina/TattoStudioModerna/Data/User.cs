using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TattoStudioModerna.Data
{
    public class User:IdentityUser
    {
        
        public string FullName { get; set; }

        public Roles Role { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
