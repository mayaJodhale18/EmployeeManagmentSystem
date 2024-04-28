using Microsoft.EntityFrameworkCore;

namespace CodeFirstAproch.Models
{
    public class StudentDB : DbContext
    {
        public StudentDB(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
