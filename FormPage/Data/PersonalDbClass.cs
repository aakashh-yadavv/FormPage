using FormPage.Models;
using Microsoft.EntityFrameworkCore;

namespace FormPage.Data
{
    public class PersonalDbClass : DbContext
    {
        public PersonalDbClass(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
