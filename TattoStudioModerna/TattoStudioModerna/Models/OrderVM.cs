using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TattoStudioModerna.Models
{
    public class OrderVM
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
       
        public int UserId { get; set; }
        
        public int TattoId { get; set; }
        
        public DateTime OrderOn { get; set; }
    }
}
