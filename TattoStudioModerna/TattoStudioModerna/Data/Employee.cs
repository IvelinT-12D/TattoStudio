using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TattoStudioModerna.Data
{
    public class Employee 
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string TattoCertifcate { get; set; }
        public string Discription { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
