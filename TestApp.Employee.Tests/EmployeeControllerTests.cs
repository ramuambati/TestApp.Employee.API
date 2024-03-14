using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TestApp.Employee.API.Controllers;
using TestApp.Employee.Contracts;
using TestApp.Employee.Interfaces;
using Xunit;
using TestApp.Employee.API.Controllers;

public class EmployeeControllerTests
{
    [Fact]
    public async Task AddEmployee_ValidEmployee_ReturnsCreatedAtAction()
    {
        // Arrange
        var employeeServiceMock = new Mock<IEmployeeService>();
        var loggerMock = new Mock<ILogger<EmployeeController>>();
        var controller = new EmployeeController(employeeServiceMock.Object, loggerMock.Object);
        var employeeInfo = new EmployeeInfo { Id = 1,Address1 = "test",FirstName = "test",LastName = "test",EmployeeType = "Employee",PayPerHour = 90  };

        // Act
        var result = await controller.AddEmployee(employeeInfo) as CreatedAtActionResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(nameof(EmployeeController.GetAllEmployees), result.ActionName);
        Assert.Equal(employeeInfo.Id, 1);
        Assert.Equal(employeeInfo.Address1, "test");
        Assert.Equal(employeeInfo.FirstName, "test");
        Assert.Equal(employeeInfo.LastName, "test");
        employeeServiceMock.Verify(service => service.AddEmployeeInfo(employeeInfo), Times.Once);
    }

    [Fact]
    public async Task GetAllEmployees_ReturnsAllEmployees()
    {
        // Arrange
        var employeeServiceMock = new Mock<IEmployeeService>();
        var loggerMock = new Mock<ILogger<EmployeeController>>();
        var controller = new EmployeeController(employeeServiceMock.Object, loggerMock.Object);
        EmployeeInfo emp = new()
        {
            Address1 = "test",
            PayPerHour = 90,
            LastName = "test",
            EmployeeType = "Employee"
        };

        var employees = new List<EmployeeInfo> { emp };
        employeeServiceMock.Setup(service => service.GetAllEmployees()).ReturnsAsync(employees);

        // Act
        var result = await controller.GetAllEmployees() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(employees, result.Value);
    }
}
