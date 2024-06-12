using prSchool.DTOs;
using prSchool.Models;
using prSchool.Repository;

namespace prSchool.Services
{
    public class StudentService : IStudentService<StudentDto, StudentInsertDto>
    {
        private IStudentRepository<Student> _studentRepository;
        public StudentService(IStudentRepository<Student> studentRepository) {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDto>> Get()
        {
            var student = await _studentRepository.Get();

            return student.Select(s => new StudentDto()
            {
                StudentID = s.StudentID,
                AccountNumber = s.AccountNumber,
                Name = s.Name,
                LastName = s.LastName,
                email = s.email
            });
        }

        public async Task<StudentDto>Add(StudentInsertDto studentInsertDto)
        {
            var student = new Student
            {
                AccountNumber = studentInsertDto.AccountNumber,
                Name = studentInsertDto.Name,
                LastName = studentInsertDto.LastName,
                email = studentInsertDto.email,
            };

            await _studentRepository.Add(student);
            await _studentRepository.Save();

            var studentDto = new StudentDto
            {
                StudentID = student.StudentID,
                AccountNumber = student.AccountNumber,
                Name = student.Name,
                LastName = student.LastName,
                email = student.email
            };

           return studentDto;

        }
    }
}
