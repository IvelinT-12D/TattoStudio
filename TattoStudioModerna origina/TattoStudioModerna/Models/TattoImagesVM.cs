using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TattoStudioModerna.Models
{
    public class TattoImagesVM
    {
        public TattoImagesVM()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public int TattoesId { get; set; }

        public List<SelectListItem> Tattoes { get; set; }

        [Required]
        public IFormFile ImagePath { get; set; }
    }
}
