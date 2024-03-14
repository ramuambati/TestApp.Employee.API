using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Employee.Contracts
{
    public class EmployeeInfo
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string? Address1 { get; set; }
        [Required]
        public string EmployeeType { get; set; }
        [Required]
        //public AdditionalInfo? AdditionalInfo { get; set; }
        public decimal? PayPerHour { get; set; }
        public decimal? AnnualSalary { get; set; }
        public decimal? MaxExpenseAmount { get; set; }
    }
}
