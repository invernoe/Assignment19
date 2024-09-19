using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Department : ModelBase
    {

        [Required(ErrorMessage = "Code is required")]
        public String Code { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Date of Creation")]
        public DateTime CreatedDate { get; set; }
    }
}
