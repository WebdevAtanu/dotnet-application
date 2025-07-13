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
            var students = await _studentRepository.GetAllStudents();
            return students.Select(student => new StudentResponse
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Age = student.Age,
                Address = student.Address,
                DepartmentId = student.DepartmentId,
                InstructorId = student.InstructorId
            }).ToList();
        }

        public async Task<StudentResponse?> GetStudentById(Guid studentId)
        {
            var student = await _studentRepository.GetStudentById(studentId);
            if (student == null) return null;

            return new StudentResponse
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Age = student.Age,
                Address = student.Address,
                DepartmentId = student.DepartmentId,
                InstructorId = student.InstructorId
            };
        }

        public async Task<StudentResponse> CreateStudent(StudentRequest request)
        {
            var student = new Student
            {
                StudentId = Guid.NewGuid(),
                Name = request.Name,
                Age = request.Age,
                Address = request.Address,
                InstructorId = request.InstructorId,
                DepartmentId = request.DepartmentId
            };

            var createdStudent = await _studentRepository.CreateStudent(student);

            return new StudentResponse
            {
                StudentId = createdStudent.StudentId,
                Name = createdStudent.Name,
                Age = createdStudent.Age,
                Address = createdStudent.Address,
                DepartmentId = createdStudent.DepartmentId,
                InstructorId = createdStudent.InstructorId
            };
        }

        public async Task<StudentResponse?> UpdateStudent(Guid studentId, StudentRequest request)
        {
            var student = await _studentRepository.GetStudentById(studentId);
            if (student == null) return null;

            student.Name = request.Name;
            student.Age = request.Age;
            student.Address = request.Address;
            student.InstructorId = request.InstructorId;
            student.DepartmentId = request.DepartmentId;

            var updated = await _studentRepository.UpdateStudent(student);

            return new StudentResponse
            {
                StudentId = updated.StudentId,
                Name = updated.Name,
                Age = updated.Age,
                Address = updated.Address,
                DepartmentId = updated.DepartmentId,
                InstructorId = updated.InstructorId
            };
        }

        public async Task<bool> DeleteStudent(Guid studentId)
        {
            return await _studentRepository.DeleteStudent(studentId);
        }
    }
}
