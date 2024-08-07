using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NCL.Components;
using NCL.Data;
using NCL.Shared.Entities;


namespace NCL.Controller
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;


        public EmployeesController(DataContext context)
        {
            _context = context;
        }
    

        [HttpGet("/api/Employees/GetEmployees")]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }


        [HttpGet("/api/Employees/{Username}")]
        public async Task<ActionResult<Employee>> GetEmployeesByUsername(string Username)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(e => e.Employee__Name == Username);
            if (result == null)
            {
                Employee result2 = new Employee()
                {
                    Employee__Name = null,
                    Employee__Log = null
                };
                return Ok(result2);
            }
            return Ok(result);
        }


        [HttpPost("/api/Employees/AddEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee addNewEmployee)
        {
            _context.Add(addNewEmployee);
            await _context.SaveChangesAsync();

            return Ok(addNewEmployee);
        }

        [HttpDelete("/api/Employees/DeleteEmployeesByUsername/{ID}")]
        public async Task<IActionResult> DeleteEmployeesByUsername(int ID)
        {

            var result = await _context.Employees.FindAsync(ID);
            if (result == null)
            {
                Employee result2 = new Employee()
                {
                    Employee__Name = null,
                    Employee__Log = null
                };
                return Ok(result2);
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(result);

        }

        [HttpPut("/api/Employees/UpdateEmployeeByID/{ID}")]
        public async Task<ActionResult<Employee>> UpdateEmployeeByID(int ID, Employee updatedEmployee)
        {
            var Employees = await _context.Employees.FindAsync(ID);
            if (Employees == null)
            {
                return Ok("Employee not found");
            }
            Employees.Employee__Log = updatedEmployee.Employee__Log;

            await _context.SaveChangesAsync();

            return Ok(Employees);
        }
    }
}
