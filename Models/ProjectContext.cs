using Microsoft.EntityFrameworkCore;
namespace massage.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users { get; set; }
    }
}