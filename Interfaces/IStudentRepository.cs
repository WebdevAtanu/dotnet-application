using demoApplication.Models;

namespace demoApplication.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(long id);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<bool> DeleteStudent(long id);
    }
}
