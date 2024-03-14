using Microsoft.EntityFrameworkCore;
using TestApp.Employee.Contracts;
using TestApp.Employee.Db;
using TestApp.Masterdb.EF.Models;

namespace TestApp.Employee.Tests
{
    public class LocalDbRepositoryTests
    {
        [Fact]
        public async Task AddEmployeeInfo_AddsEmployeeToDbContext()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<LocalDBContext>()
                .UseInMemoryDatabase(databaseName: "Test_LocalDB")
                .Options;

            using var dbContext = new LocalDBContext(options);
            var repository = new LocalDbRepository(dbContext);

            var employeeInfo = new EmployeeInfo
            {
                Id = 99,
                FirstName = "Rama",
                LastName = "Ambati",
                Address1 = "123 Main St",
                EmployeeType = "Employee",
                PayPerHour = 100
            };

            // Act
            await repository.AddEmployeeInfo(employeeInfo);

            // Assert
            var worker = await dbContext.Workers.FindAsync(employeeInfo.Id);
            var employee = await dbContext.Employees.FindAsync(employeeInfo.Id);

            Assert.NotNull(worker);
            Assert.Equal(employeeInfo.FirstName, worker.FirstName);
            Assert.Equal(employeeInfo.LastName, worker.LastName);
            Assert.Equal(employeeInfo.Address1, worker.Address1);            
        }

        [Fact]
        public async Task GetAllEmployees_ReturnsAllEmployeesFromDbContext()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<LocalDBContext>()
                .UseInMemoryDatabase(databaseName: "Test_LocalDB")
                .Options;

            using (var dbContext = new LocalDBContext(options))
            {               
                dbContext.Workers.AddRange(new List<Worker>
                {
                    new() { WorkerID = 1, FirstName = "Test", LastName = "LastName", Address1 = "123 Main St" },
                    new() { WorkerID = 2, FirstName = "FirstName", LastName = "Test", Address1 = "456 Elm St" }
                });
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new LocalDBContext(options))
            {
                var repository = new LocalDbRepository(dbContext);

                // Act
                var result = await repository.GetAllEmployees();

                // Assert
                Assert.Equal(2, result.Count());            
            }
        }
    }
}
