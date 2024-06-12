namespace prSchool.Services
{
    public interface IStudentService<T>
    {
        Task<IEnumerable<T>> Get();
    }
}
