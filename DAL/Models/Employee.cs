﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public enum EmployeeType
    {
        FullTime = 1,
        PartTime = 2
    }

    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Max length for name is 50")]
        [MinLength(4, ErrorMessage = "Min length for name is 4")]
        public string Name { get; set; }
        [Range(21, 60)]
        public int? Age { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        public bool IsDeleted { get; set; }

        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}