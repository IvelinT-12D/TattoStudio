using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TattoStudioModerna.Models
{
    public class OrderVM
    {
        public int Id { get; set; }
        public int TattoId { get; set; }
        public List<SelectListItem> Tatto { get; set; }
       
        public string UserId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на закупуване: ")]
        public DateTime OrderOn { get; set; }

        //public int EmployeeId { get; set; }
        //public List<SelectListItem> Employee { get; set; }



    }
}
