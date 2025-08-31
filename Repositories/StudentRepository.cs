using demoApplication.Dto;
using demoApplication.Interfaces;
using demoApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace demoApplication.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyDbContext _context;

        public StudentRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentResponse>> GetAllStudents()
        {
            return await _context.Students.Select(student => new StudentResponse
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Age = student.Age,
                Address = student.Address,
            }).ToListAsync();
        }

        public async Task<StudentResponse?> GetStudentById(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);

            if (student == null)
                return null;

            return new StudentResponse
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Age = student.Age,
                Address = student.Address
            };
        }

        public async Task<bool> CreateStudent(StudentRequest studentRequest)
        {
            var student = new Student
            {
                Name = studentRequest.Name,
                Age = studentRequest.Age,
                Address = studentRequest.Address,
            };

            _context.Students.Add(student);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> UpdateStudent(int studentId, StudentRequest studentRequest)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
            {
                return false;
            }

            student.Name = studentRequest.Name;
            student.Age = studentRequest.Age;
            student.Address = studentRequest.Address;

            _context.Students.Update(student);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
