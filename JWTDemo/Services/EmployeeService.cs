using JWTDemo.Context;
using JWTDemo.Interface;
using JWTDemo.Model;

namespace JWTDemo.Services
{
    public class EmployeeService : IEmployees
    {
        private readonly JWTContext _jwtContext;
        public EmployeeService(JWTContext jwtContext)
        {
            _jwtContext = jwtContext;
        }
        public Employee AddEmployees(Employee employee)
        {
            var emp = _jwtContext.Employees.Add(employee);
            _jwtContext.SaveChanges();
            return emp.Entity;
        }

        public bool DeleteEmployees(int id)
        {
            try
            {
                var emp = _jwtContext.Employees.SingleOrDefault(s => s.Id == id);
                if (emp == null)
                    throw new Exception("user not found");
                else
                {
                    _jwtContext.Employees.Remove(emp);
                    _jwtContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<Employee> GetEmployees()
        {
            var employees = _jwtContext.Employees.ToList();
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            var emp = _jwtContext.Employees.SingleOrDefault(s => s.Id == id);
            return emp;
        }

        public Employee UpdateEmployees(Employee employee)
        {
            var updated = _jwtContext.Employees.Update(employee);
            _jwtContext.SaveChanges();
            return updated.Entity;
        }
    }
}
