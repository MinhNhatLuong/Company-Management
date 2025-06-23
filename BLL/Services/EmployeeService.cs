using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }
        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }
        public List<Employee> GetEmployeesBySearch(string searchTerm)
        {
            return _employeeRepository.GetEmployeesBySearch(searchTerm);
        }
        public void DeleteAEmployee(Employee employee)
        {
            _employeeRepository.DeleteAEmployee(employee);
        }

        public void AddAnEmployee(Employee employee)
        {
            _employeeRepository.AddAnEmployee(employee);
        }

        public void UpdateAnEmployee(Employee employee)
        {
            _employeeRepository.UpdateAnEmployee(employee);
        }
    }
}
