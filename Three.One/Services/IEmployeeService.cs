using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.One.Models;

namespace Three.One.Services
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);
        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);
        Task<Employee> File(int id);
    }
}
