

using Microsoft.EntityFrameworkCore;

namespace FirstCrudOperation_.net_core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // this is the table name in the database
        public DbSet<User> Users { get; set; }
    }
}
