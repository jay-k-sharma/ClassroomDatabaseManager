using Microsoft.EntityFrameworkCore;

namespace ClassroomDatabaseManager.Models
{
    public class ClassroomContext : DbContext
    {
        public ClassroomContext(DbContextOptions<ClassroomContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
