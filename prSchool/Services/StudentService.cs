using prSchool.DTOs;
using prSchool.Models;
using prSchool.Repository;

namespace prSchool.Services
{
    public class StudentService : IStudentService<StudentDto>
    {
        private IStudentRepository<Student> _studentRepository;
        public StudentService(IStudentRepository<Student> studentRepository) {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDto>> Get()
        {
            var student=await _studentRepository.Get();

            return student.Select(s => new StudentDto()
            {
                StudentID=s.StudentID,
                AccountNumber=s.AccountNumber,
                Name=s.Name,
                LastName=s.LastName,
                email=s.email
            });
        }
    }
}
