using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace demoApplication.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) 
        : base(options)
    {
    }
    public virtual DbSet<Student> Students { get; set; }

}
