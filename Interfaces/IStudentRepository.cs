using demoApplication.Models;

namespace demoApplication.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();
        Task<Student?> GetStudentById(Guid studentId);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<bool> DeleteStudent(Guid studentId);
    }
}
