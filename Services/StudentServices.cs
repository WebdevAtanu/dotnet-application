using demoApplication.Dto;
using demoApplication.Interfaces;
using demoApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoApplication.Services
{
    public class StudentServices : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDto>> GetStudents()
        {
            var students = await _studentRepository.GetStudents();
            return students.Select(student => new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age
            }).ToList();
        }

        public async Task<StudentDto?> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null) return null;

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age
            };
        }

        public async Task<StudentDto> CreateStudent(StudentDto studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Age = studentDto.Age
            };

            var createdStudent = await _studentRepository.CreateStudent(student);

            return new StudentDto
            {
                Id = createdStudent.Id,
                Name = createdStudent.Name,
                Age = createdStudent.Age
            };
        }

        public async Task<StudentDto?> UpdateStudent(int id, StudentDto studentDto)
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null) return null;

            student.Name = studentDto.Name;
            student.Age = studentDto.Age;

            var updatedStudent = await _studentRepository.UpdateStudent(student);

            return new StudentDto
            {
                Id = updatedStudent.Id,
                Name = updatedStudent.Name,
                Age = updatedStudent.Age
            };
        }

        public async Task<bool> DeleteStudent(int id)
        {
            return await _studentRepository.DeleteStudent(id);
        }
    }
}
