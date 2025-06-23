using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EmployeeRepository
    {
        private readonly CompanyDbContext _dbContext;

        public EmployeeRepository()
        {
            _dbContext = new CompanyDbContext();
        }

        public List<Employee> GetEmployees()
        {
            //xuống database, vào bảng employee để lấy database
            //join với bảng department (từ khóa include)
            //cách 1: viết đúng tên
            //var employees = _dbContext.Employees.Include("Department").ToList();

            //cách 2: lambda
            var employees = _dbContext.Employees.Include(x => x.Department).ToList();
            return employees;
        }

        public List<Employee> GetEmployeesBySearch(string searchTerm)
        {
            //LINQ does not support convert ignore case to SQL
            var employees = _dbContext.Employees
                .Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) || x.Address.Contains(searchTerm.ToLower()))
                .ToList();
            return (List<Employee>)employees;
        }

        public void DeleteAEmployee(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }

        public void AddAnEmployee(Employee employee)
        {
            employee.Id = _dbContext.Employees.Max(x => x.Id) + 1;
            _dbContext.Add(employee);
            _dbContext.SaveChanges();
        }

        public void UpdateAnEmployee(Employee employee)
        {
            //xuống database kiếm
            var employeeDb = _dbContext.Employees.Find(employee.Id);
            //nếu có thì lấy thông tin rồi update, nếu không thì null
            if (employeeDb != null)
            {
                employeeDb.Name = employee.Name;
                employeeDb.Address = employee.Address;
                employeeDb.DepartmentId = employee.DepartmentId;
                employeeDb.Age = employee.Age;
                _dbContext.Update(employeeDb);
                _dbContext.SaveChanges();
            }
        }
    }
}
