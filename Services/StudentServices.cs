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
        private readonly IStudentInterface _studentInterface;

        public StudentServices(IStudentInterface studentInterface)
        {
            _studentInterface = studentInterface;
        }

        public async Task<IEnumerable<StudentDto>> GetStudents()
        {
            var students = await _studentInterface.GetStudents();
            return students.Select(student => new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age
            }).ToList();
        }

        public async Task<StudentDto?> GetStudentById(int id)
        {
            var student = await _studentInterface.GetStudentById(id);
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

            var createdStudent = await _studentInterface.CreateStudent(student);

            return new StudentDto
            {
                Id = createdStudent.Id,
                Name = createdStudent.Name,
                Age = createdStudent.Age
            };
        }

        public async Task<StudentDto?> UpdateStudent(int id, StudentDto studentDto)
        {
            var student = await _studentInterface.GetStudentById(id);
            if (student == null) return null;

            student.Name = studentDto.Name;
            student.Age = studentDto.Age;

            var updatedStudent = await _studentInterface.UpdateStudent(student);

            return new StudentDto
            {
                Id = updatedStudent.Id,
                Name = updatedStudent.Name,
                Age = updatedStudent.Age
            };
        }

        public async Task<bool> DeleteStudent(int id)
        {
            return await _studentInterface.DeleteStudent(id);
        }
    }
}
