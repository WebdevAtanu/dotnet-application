using System.ComponentModel.DataAnnotations;

namespace demoApplication.Dto;

public class StudentResponse
{
    public Guid StudentId { get; set; }
    public string? Name { get; set; }
    public int? Age { get; set; }
    public string? Address { get; set; }
    public Guid? InstructorId { get; set; }
    public Guid? DepartmentId { get; set; }
}
