namespace prSchool.Repository
{
    public interface IStudentRepository<Tentity>
    {
        Task<IEnumerable<Tentity>> Get();
        Task Add(Tentity entity);
        Task Save();
    }
}
