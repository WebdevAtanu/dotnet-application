using demoApplication.Dto;
using demoApplication.Interfaces;
using demoApplication.Models;

namespace demoApplication.Services
{
    public class StudentServices : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentResponse>> GetAllStudents()
        {
            return await _studentRepository.GetAllStudents();
        }

        public async Task<StudentResponse?> GetStudentById(int studentId)
        {
            return await _studentRepository.GetStudentById(studentId);
        }

        public async Task<bool> CreateStudent(StudentRequest studentRequest)
        {
            return await _studentRepository.CreateStudent(studentRequest);
        }

        public async Task<bool> UpdateStudent(int studentId, StudentRequest studentRequest)
        {
            var student = await _studentRepository.GetStudentById(studentId);
            if (student == null) return false;

            return await _studentRepository.UpdateStudent(studentId, studentRequest);
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            return await _studentRepository.DeleteStudent(studentId);
        }
    }
}
