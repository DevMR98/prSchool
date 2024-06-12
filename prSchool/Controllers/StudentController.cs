using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using prSchool.DTOs;
using prSchool.Services;

namespace prSchool.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService<StudentDto> _studentService;

        public StudentController(IStudentService<StudentDto> studentService)
        {
            _studentService = studentService;
        }

        public async Task<ActionResult<IEnumerable<StudentDto>>> Index()
        {
            var student = await _studentService.Get();
            return View(student);
        }
    }
}
