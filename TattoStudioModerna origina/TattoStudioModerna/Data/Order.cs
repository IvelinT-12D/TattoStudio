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
       
        public string UserId { get; set; }
        public User User { get; set; }
        public int TattoId {get; set;}
        public Tatto Tatto { get; set; }
       public DateTime OrderOn { get; set; }

      


    }
}
