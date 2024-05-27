using EmployeeAPI.Entities;
using EmployeeAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetDepartmentDetails")]
        public async Task<ActionResult<List<Department>>> GetDepartmentDetails()
        {
            var result = await _departmentService.GetDepartmentDetails();
            return Ok(result);
        }

        [HttpPost("PushDepartment")]
        public ActionResult PushDepartment([FromBody] Department department)
        {
            if (department.Name == null || string.IsNullOrEmpty(department.Name))
            {
                return BadRequest("Invalid Employee data.");
            }
            _departmentService.PushDepartment(department);
            return Ok("Department added successfully.");
        }

        [HttpDelete("DeleteDepartment/{id}")]
        public ActionResult DeleteDepartment(int id)
        {
            _departmentService.DeleteDepartment(id);
            return Ok("Department deleted successfully.");
        }


        [HttpPut("UpdateDepartment")]
        public ActionResult UpdateEmployee(Department department)
        {
            _departmentService.UpdateDepartment(department);
            return Ok("Department Update successfully.");
        }

        [HttpGet("SearchDepartment")]
        public async Task<ActionResult<List<object>>> SearchDepartment(string? search)
        {
            var result = await _departmentService.SearchDepartment(search);

            return Ok(result);
        }
    }
}
