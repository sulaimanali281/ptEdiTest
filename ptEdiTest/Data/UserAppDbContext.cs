using Microsoft.EntityFrameworkCore;
using ptEdiTest.Models;

namespace ptEdiTest.Data
{
    public class UserAppDbContext : DbContext
    {
        public UserAppDbContext(DbContextOptions<UserAppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}

