using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Three.One.Models;
using Three.One.Services;

namespace Three.One.Controllers
{
    public class EmployeeController: Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        //不写默认是[HttpGet]
        public async Task<IActionResult> Index(int departmentId)
        {
            var department = await _departmentService.GetById(departmentId);

            ViewBag.Title = $"Employee of {department.Name}";
            ViewBag.DepartmentId = departmentId;

            var employee = await _employeeService.GetByDepartmentId(departmentId);

            return View(employee);
        }

        //不写默认是[HttpGet]
        public IActionResult Add(int departmentId)
        {
            ViewBag.Title = "Add Employee";
            return View(new Employee
            {
                DepartmentId = departmentId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Add(model);
            }

            return RedirectToAction(nameof(Index), routeValues: new { departmentId = model.DepartmentId });
        }

        //不写默认是[HttpGet]
        public async Task<IActionResult> Fire(int employeeId)
        {
            var employee = await _employeeService.File(employeeId);

            return RedirectToAction(nameof(Index), routeValues: new { departmentId = employee.DepartmentId });
        }
    }
}
