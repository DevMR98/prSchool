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

        public async Task<Student> GetById(int studentID) => await _context.Student.FindAsync(studentID);
        public async Task Add (Student student)=> await _context.Student.AddAsync(student);

        public void Update(Student student)
        {
            //marcamos en la bd por ef si existe el dato
            _context.Student.Attach(student);
            //
            _context.Student.Entry(student).State=EntityState.Modified;

        }
        public void Delete(Student student)=>_context.Student.Remove(student);
        public async Task Save()=>await _context.SaveChangesAsync();
    }
}
