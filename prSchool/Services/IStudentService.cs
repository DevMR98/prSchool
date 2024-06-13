using prSchool.DTOs;

namespace prSchool.Services
{
    public interface IStudentService<T,Ti,Tu>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int studentID);
        Task<T>Add(Ti entity);
        Task<T> Update(int studentID,Tu entity);

    }
}
