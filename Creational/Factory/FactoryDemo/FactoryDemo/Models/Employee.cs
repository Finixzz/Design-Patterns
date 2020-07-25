using FactoryDemo.AppDbContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last name")]
        public string LastName { get; set; }

        [Required]
        public string Department { get; set; }

        public decimal HourlyPay { get; set; }

        public decimal Bonus { get; set; }

        [Required]
        public int EmployeeTypeId { get; set; }

        public EmployeeType EmployeeType { get; set; }
    }
}
