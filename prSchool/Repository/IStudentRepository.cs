namespace prSchool.Repository
{
    public interface IStudentRepository<Tentity>
    {
        Task<IEnumerable<Tentity>> Get();
        Task<Tentity> GetById(int stundentID);
        Task Add(Tentity entity);
        void Update(Tentity entity);
        Task Save();
    }
}
