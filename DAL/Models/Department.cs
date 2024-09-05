﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public String Code { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
