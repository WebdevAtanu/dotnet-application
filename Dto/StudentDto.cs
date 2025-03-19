using System.ComponentModel.DataAnnotations;

namespace demoApplication.Dto;

public class StudentDto
{

    public long Id { get; set; }
    // validation implemented
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Age is required.")]
    [Range(1, 100, ErrorMessage = "Age must be between 1 and 100.")]
    public string? Age { get; set; }
}
