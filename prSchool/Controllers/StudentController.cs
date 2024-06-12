using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using prSchool.DTOs;
using prSchool.Services;

namespace prSchool.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService<StudentDto, StudentInsertDto> _studentService;

        public StudentController(IStudentService<StudentDto, StudentInsertDto> studentService)
        {
            _studentService = studentService;
        }

        public async Task<ActionResult<IEnumerable<StudentDto>>> Index()
        {
            var student = await _studentService.Get();
            return View(student);
        }

        public async Task<ActionResult>Add(StudentInsertDto studentInsertDto){
            if (!ModelState.IsValid) { 
                return View(studentInsertDto); 
            }
            var student=await _studentService.Add(studentInsertDto);

            return RedirectToAction(nameof(Index));
            
        }
    }
}
