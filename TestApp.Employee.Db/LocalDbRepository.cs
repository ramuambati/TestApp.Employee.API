using Microsoft.EntityFrameworkCore;
using TestApp.Employee.Contracts;
using TestApp.Employee.Interfaces;
using TestApp.Masterdb.EF.Models;

namespace TestApp.Employee.Db
{
    public class LocalDbRepository : ILocalDbRepository
    {
        private readonly LocalDBContext _dbContext;

        public LocalDbRepository(LocalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task ILocalDbRepository.AddEmployeeInfo(EmployeeInfo employeeInfo)
        {
            Worker worker = new()
            {
                Address1 = employeeInfo.Address1,
                LastName = employeeInfo.LastName,
                FirstName = employeeInfo.FirstName,
                WorkerID = employeeInfo.Id                
            };

            await _dbContext.Workers.AddAsync(worker);
            //await _dbContext.SaveChangesAsync();

            switch (employeeInfo.EmployeeType)
            {
                case "Employee":
                    Masterdb.EF.Models.Employee employee = new()
                    {
                        PayPerHour = employeeInfo.PayPerHour ,
                        WorkerID = employeeInfo.Id
                    };
                    await _dbContext.Employees.AddAsync(employee);
                    //await _dbContext.SaveChangesAsync();
                    break;
                case "Manager":
                    Manager manager = new()
                    {
                        AnnualSalary = employeeInfo.AnnualSalary,
                        MaxExpenseAmount = employeeInfo.MaxExpenseAmount,
                        WorkerID = employeeInfo.Id
                    };
                    await _dbContext.Managers.AddAsync(manager);
                   // await _dbContext.SaveChangesAsync();
                    break;
                case "Supervisor":
                    Supervisor supervisor = new()
                    {
                        AnnualSalary = employeeInfo.AnnualSalary,
                        WorkerID = employeeInfo.Id
                    };
                    await _dbContext.Supervisors.AddAsync(supervisor);
                   // await _dbContext.SaveChangesAsync();
                    break;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeInfo>> GetAllEmployees()
        {
            var query = from p in _dbContext.Workers
                        join e in _dbContext.Employees on p.WorkerID equals e.WorkerID into employeeGroup
                        from emp in employeeGroup.DefaultIfEmpty()
                        join m in _dbContext.Managers on p.WorkerID equals m.WorkerID into managerGroup
                        from mgr in managerGroup.DefaultIfEmpty()
                        join s in _dbContext.Supervisors on p.WorkerID equals s.WorkerID into supervisorGroup
                        from sup in supervisorGroup.DefaultIfEmpty()
                        select new EmployeeInfo
                        {
                            Id = p.WorkerID,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            Address1 = p.Address1,
                            EmployeeType = emp != null ? "Employee" : (mgr != null ? "Manager" : (sup != null ? "Supervisor" : null)),
                            PayPerHour = emp != null ? emp.PayPerHour : (int?)null,
                            AnnualSalary = mgr != null ? mgr.AnnualSalary : (sup != null ? sup.AnnualSalary : (int?)null),
                            MaxExpenseAmount = mgr != null ? mgr.MaxExpenseAmount : (int?)null
                        };

            return await query.ToListAsync();
        }

    }
}
