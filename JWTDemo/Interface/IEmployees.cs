using JWTDemo.Model;

namespace JWTDemo.Interface
{
    public interface IEmployees
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployee(int id);    
        public Employee AddEmployees(Employee employee);
        public Employee UpdateEmployees(Employee employee);
        public bool DeleteEmployees(int id);    
         
    }
}
