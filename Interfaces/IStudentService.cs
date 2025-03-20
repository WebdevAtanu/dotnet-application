using demoApplication.Dto;

namespace demoApplication.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetStudents();
        Task<StudentDto?> GetStudentById(int id);
        Task<StudentDto> CreateStudent(StudentDto studentDto);
        Task<StudentDto?> UpdateStudent(int id, StudentDto studentDto);
        Task<bool> DeleteStudent(int id);
    }
}



