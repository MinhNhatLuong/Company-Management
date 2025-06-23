using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DAL.Repositories
{
    public class DepartmentRepository
    {
        private readonly CompanyDbContext _dbContext;
        public DepartmentRepository()
        {
            _dbContext = new CompanyDbContext();
        }

        public List<Department> GetDepartments()
        {
            var Deparments = _dbContext.Departments.ToList();
            return Deparments;
        }
    }
}
