using Microsoft.EntityFrameworkCore;

namespace prSchool.Models
{
    public class SchoolContext : DbContext 
    {
        public SchoolContext(DbContextOptions<SchoolContext> options):base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
    }
}
