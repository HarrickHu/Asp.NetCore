using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Three.One.Services;

namespace ThreePage.Pages.Department
{
    public class AddDepartmentModel : PageModel
    {
        private readonly IDepartmentService _departmentService;

        [BindProperty]
        public Three.One.Models.Department Department { get; set; }       

        public AddDepartmentModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _departmentService.Add(Department);
            return RedirectToPage("/Index");
        }
    }
}
