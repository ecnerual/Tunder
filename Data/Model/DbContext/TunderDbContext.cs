using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace tunder.Model.DbContext
{
    public class TunderDbContext : Microsoft.EntityFrameworkCore.DbContext, ITunderDbContext
    {
        public DbSet<User> Users { get; set; }

        public TunderDbContext(DbContextOptions<TunderDbContext> options) : base(options)
        {

        }
       
    }
}