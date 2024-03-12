using JWTDemo.Interface;
using JWTDemo.Model;
using JWTDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployees _employeesService;
        public EmployeeController(IEmployees employeeService) 
        {
            _employeesService = employeeService;
        }
        
        [HttpGet]
        public List<Employee> Get()
        {
            var employees = _employeesService.GetEmployees();   
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var emp = _employeesService.GetEmployee(id);
            return emp;
        }

        [HttpPost]
        public Employee Post([FromBody] Employee value)
        {
            var emp = _employeesService.AddEmployees(value);
            return emp;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public Employee Put(int id, [FromBody] Employee value)
        {
            var emp = _employeesService.UpdateEmployees(value);
            return emp;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var isDeleted = _employeesService.DeleteEmployees(id);
            return isDeleted;
        }
    }
}
