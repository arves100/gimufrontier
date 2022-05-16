#nullable disable

using gimufrontier.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace gimufrontier
{
    public class GimuDbContext : DbContext
    {
        public GimuDbContext(DbContextOptions<GimuDbContext> options) : base(options)
        {

        }

        public DbSet<UserDb> Users { get; set; }
        public DbSet<FacebookUserDb> FacebookUsers { get; set; }
    }
}
