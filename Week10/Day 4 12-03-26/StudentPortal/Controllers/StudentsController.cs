using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Services;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRequestLogService _logService;

        public StudentsController(IRequestLogService logService)
        {
            _logService = logService;
        }

        public IActionResult Index()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Rahul", Age = 20 },
                new Student { Id = 2, Name = "Priya", Age = 21 }
            };

            var viewModel = new StudentIndexViewModel
            {
                Students = students,
                Logs = _logService.GetLogs()
            };

            return View(viewModel);
        }
    }
}