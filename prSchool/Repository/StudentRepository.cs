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

    }
}
