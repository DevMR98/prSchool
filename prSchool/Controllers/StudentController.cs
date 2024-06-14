using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using prSchool.DTOs;
using prSchool.Services;

namespace prSchool.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService<StudentDto, StudentInsertDto, StudentUpdateDto> _studentService;

        public StudentController(IStudentService<StudentDto, StudentInsertDto, StudentUpdateDto> studentService)
        {
            _studentService = studentService;
        }

        public async Task<ActionResult<IEnumerable<StudentDto>>> Index()
        {
            var student = await _studentService.Get();
            return View(student);
        }
        [HttpGet("edit/{id}")]
        public async Task<ActionResult<StudentDto>> edit(int id)
        {
            var student = await _studentService.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);

        }

        public ActionResult Create()
        {
            return View();
        }
        public async Task<ActionResult>Add(StudentInsertDto studentInsertDto){
            if (!ModelState.IsValid) { 
                return View(studentInsertDto); 
            }
            var student=await _studentService.Add(studentInsertDto);

            return RedirectToAction(nameof(Index));
            
        }

        [HttpPost("edit/{id}")]
        public async Task<ActionResult> Edit(int id,StudentUpdateDto student)
        {
         
            await _studentService.Update(id,student);

            return RedirectToAction(nameof(Index));
        }


    }
}
