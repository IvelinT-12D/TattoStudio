using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TattoStudioModerna.Data
{
    public class Employee 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
