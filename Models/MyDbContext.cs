using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace demoApplication.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) // constructor
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; } // db set defined for student model

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().ToTable("Student"); // it maps to the correct table name
    }

}
