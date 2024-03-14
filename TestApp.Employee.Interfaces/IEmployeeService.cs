using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Employee.Contracts;

namespace TestApp.Employee.Interfaces
{
    public interface IEmployeeService
    {
        Task AddEmployeeInfo(EmployeeInfo employeeInfo);

        Task <IEnumerable<EmployeeInfo>> GetAllEmployees();
    }
}
