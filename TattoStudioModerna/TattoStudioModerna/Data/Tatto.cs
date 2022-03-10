using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TattoStudioModerna.Data
{
    public class Tatto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Discription { get; set; }
        [Column(TypeName = "decimal(18,2")]
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Tatto> Tattos { get; set; }
       
    }
}
