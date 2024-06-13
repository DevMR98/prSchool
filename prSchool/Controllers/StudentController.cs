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

        public async Task<ActionResult<StudentDto>> GetById(int studentID)
        {
            var student = await _studentService.GetById(studentID);

            return View("edit",student);

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


        public async Task<ActionResult>Update(int studentID,StudentUpdateDto studentUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(studentUpdateDto);
            }

            var student = await _studentService.Update( studentID, studentUpdateDto);

            return RedirectToAction(nameof(Index));
        }

        
    }
}
