using System.ComponentModel.DataAnnotations;

namespace demoApplication.Dto;

public class StudentRequest
{
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Age is required.")]
    [Range(1, 100, ErrorMessage = "Age must be between 1 and 100.")]
    public int? Age { get; set; }
    public string? Address { get; set; }
}
