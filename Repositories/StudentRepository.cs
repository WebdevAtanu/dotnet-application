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
            this._context = context;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(long id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteStudent(long id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
