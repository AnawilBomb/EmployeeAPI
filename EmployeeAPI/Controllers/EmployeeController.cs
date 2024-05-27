using EmployeeAPI.Data;
using EmployeeAPI.Entities;
using EmployeeAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetEmployeeDetails")]
        public async Task<List<object>> GetEmployeeDetails()
        {
            var result = await _employeeService.GetEmployeeDetails();

            return result;
        }

        [HttpPost("PushEmployee")]
        public ActionResult PushEmployee([FromBody] Employee employee)
        {
            if (employee.FirstName == null || string.IsNullOrEmpty(employee.FirstName))
            {
                return BadRequest("Invalid Employee data.");
            }

            _employeeService.PushEmployee(employee);
            return Ok("Employee added successfully.");
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok("Employee deleted successfully.");
        }


        [HttpPut("UpdateEmployee")]
        public ActionResult UpdateEmployee(Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
            return Ok("Employee Update successfully.");
        }

        [HttpGet("SearchEmployee")]
        public async Task<ActionResult<List<object>>> SearchEmployee(string? search)
        {
            var result = await _employeeService.SearchEmployee(search);

            return Ok(result);
        }
    }
}

