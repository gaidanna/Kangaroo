using KangarooTest.Models;
using Microsoft.EntityFrameworkCore;

namespace KangarooTest.Persistence
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
    }
}
