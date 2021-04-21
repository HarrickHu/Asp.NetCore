using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Three.One.Models;
using Three.One.Services;

namespace Three.One.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IOptions<ThreeOptions> _threeOptions;

        public DepartmentController(IDepartmentService departmentService, IOptions<ThreeOptions> threeOptions)
        {
            _departmentService = departmentService;
            _threeOptions = threeOptions;
        }

        //不写默认是[HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Department Index";
            var departments = await _departmentService.GetAll();
            return View(departments);
        }

        //不写默认是[HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add Department";
            return View(new Department());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Department model) 
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Add(model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
