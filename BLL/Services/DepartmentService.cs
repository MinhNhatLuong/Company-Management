using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class DepartmentService
    {
        private readonly DepartmentRepository _departmentRepository;
        public DepartmentService()
        {
            _departmentRepository = new DepartmentRepository();
        }
        public List<Department> GetDepartments()
        {
            return _departmentRepository.GetDepartments();
        }
    }
}
