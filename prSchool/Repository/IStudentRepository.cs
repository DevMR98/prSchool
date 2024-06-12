namespace prSchool.Repository
{
    public interface IStudentRepository<Tentity>
    {
        Task<IEnumerable<Tentity>> Get();
    }
}
