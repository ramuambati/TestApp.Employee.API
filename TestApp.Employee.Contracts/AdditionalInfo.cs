using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Employee.Contracts
{
    public class AdditionalInfo
    {
        public int? PayPerHour { get; set; }
        public int? AnnualSalary { get; set; }
        public int? MaxExpensesAmount { get; set; }
    }
}
