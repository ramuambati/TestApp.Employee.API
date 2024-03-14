using Microsoft.AspNetCore.Mvc;
using TestApp.Employee.Contracts;
using TestApp.Employee.Interfaces;

namespace TestApp.Employee.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(contentType:"application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesErrorResponseType(typeof(ValidationProblemDetails))]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeInfo employeeInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            
            await _employeeService.AddEmployeeInfo(employeeInfo);
            return CreatedAtAction(nameof(GetAllEmployees), new { id = employeeInfo.Id }, employeeInfo);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllEmployees()
        {  
            return Ok(await _employeeService.GetAllEmployees());
        }
    }
}
