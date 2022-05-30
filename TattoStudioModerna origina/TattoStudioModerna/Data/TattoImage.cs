using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TattoStudioModerna.Data
{
    public class TattoImage
    {
        public TattoImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        public string ImagePath { get; set; }

      
        [Required]
      
        public int TattoId { get; set; }

        public Tatto Tatto { get; set; }
    }
}
