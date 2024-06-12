using prSchool.DTOs;

namespace prSchool.Services
{
    public interface IStudentService<T,Ti>
    {
        Task<IEnumerable<T>> Get();
        Task<T>Add(Ti entity);

    }
}
