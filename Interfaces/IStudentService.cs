using demoApplication.Dto;

namespace demoApplication.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentResponse>> GetAllStudents();
        Task<StudentResponse?> GetStudentById(int studentId);
        Task<bool> CreateStudent(StudentRequest studentRequest);
        Task<bool> UpdateStudent(int studentId, StudentRequest studentRequest);
        Task<bool> DeleteStudent(int studentId);
    }
}
