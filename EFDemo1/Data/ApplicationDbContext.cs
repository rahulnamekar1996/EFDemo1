using System.Collections.Generic;
using EFDemo1.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDemo1.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }


    }
}
