using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Employee.Contracts;
using TestApp.Employee.Interfaces;

namespace TestApp.Employee.Service
{
    public class EmployeeService : IEmployeeService
    {

        private readonly ILocalDbRepository _localDbRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(ILocalDbRepository localDbRepository, ILogger<EmployeeService> logger)
        {
            _localDbRepository = localDbRepository;
            _logger = logger;
        }

        public async Task AddEmployeeInfo(EmployeeInfo employeeInfo)
        {
            await _localDbRepository.AddEmployeeInfo(employeeInfo);
        }

        public async Task<IEnumerable<EmployeeInfo>> GetAllEmployees()
        {
            return await _localDbRepository.GetAllEmployees();
        }
    }
}
