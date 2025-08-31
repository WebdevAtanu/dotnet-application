using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoApplication.Models;

[Table("student")]
public partial class Student
{
    [Key]
    public int StudentId { get; set; }
    public string? Name { get; set; }
    public int? Age { get; set; }
    public string? Address { get; set; }
}
