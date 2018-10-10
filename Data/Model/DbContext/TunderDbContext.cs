using Microsoft.EntityFrameworkCore;

namespace tunder.Model.DbContext
{
    public class TunderDbContext : Microsoft.EntityFrameworkCore.DbContext, ITunderDbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tunder.db");
        }
    }
}