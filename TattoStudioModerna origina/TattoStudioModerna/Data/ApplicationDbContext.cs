using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TattoStudioModerna.Data;
using TattoStudioModerna.Models;

namespace TattoStudioModerna.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       public DbSet<Employee> Employees { get; set; }
       public DbSet<Tatto> Tatto { get; set; }
       public DbSet<Order> Order { get; set; }
      
        
    }
}
