using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TattoStudioModerna.Data
{
    public class Order 
    {
       public int Id { get; set; }
       public int EmployeeId { get; set; }
       public Employee Employee { get; set; }
       public int UserId { get; set; }
       public User User { get; set; }
       public DateTime OrderOn { get; set; }

    }
}
