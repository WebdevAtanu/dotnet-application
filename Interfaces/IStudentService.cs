using demoApplication.Dto;

namespace demoApplication.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentResponse>> GetAllStudents();
        Task<StudentResponse?> GetStudentById(Guid studentId);
        Task<StudentResponse> CreateStudent(StudentRequest studentRequest);
        Task<StudentResponse?> UpdateStudent(Guid studentId, StudentRequest studentRequest);
        Task<bool> DeleteStudent(Guid studentId);
    }
}
