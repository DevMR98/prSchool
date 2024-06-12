using Microsoft.EntityFrameworkCore;
using prSchool.Models;

namespace prSchool.Repository
{
    public class StudentRepository:IStudentRepository<Student>
    {
        private SchoolContext _context;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> Get() => await _context.Student.ToListAsync();

        public async Task Add (Student student)=> await _context.Student.AddAsync(student);

        public async Task Save()=>await _context.SaveChangesAsync();
    }
}
