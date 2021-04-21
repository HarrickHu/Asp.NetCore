using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.One.Models;

namespace Three.One.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly List<Department> _departments = new List<Department>();

        public DepartmentService()
        {
            _departments.Add(new Department
            {
                Id = 1,
                Name = "HR",
                EmployeeCount = 16,
                Location = "Beijing"
            });
            _departments.Add(new Department
            {
                Id = 2,
                Name = "R&D",
                EmployeeCount = 52,
                Location = "Shanghai"
            });
            _departments.Add(new Department
            {
                Id = 3,
                Name = "Sales",
                EmployeeCount = 200,
                Location = "China"
            });
        }


        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(function: () => _departments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(function: () => _departments.FirstOrDefault(p => p.Id == id));
        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(function: () =>
            {
                return new CompanySummary
                {
                    EmployeeCount = _departments.Sum(p => p.EmployeeCount),
                    AverageDepartmentEmployeeCount = (int)_departments.Average(p => p.EmployeeCount)
                };
            });
        }

        public Task Add(Department department)
        {
            department.Id = _departments.Max(p => p.Id) + 1;
            _departments.Add(department);
            return Task.CompletedTask;
        }
    }
}
