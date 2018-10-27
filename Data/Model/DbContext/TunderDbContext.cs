using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Model.DbContext
{
    public class TunderDbContext : Microsoft.EntityFrameworkCore.DbContext, ITunderDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MatchAction> Matches { get; set; }

        public TunderDbContext(DbContextOptions<TunderDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchAction>()
                .HasOne(ma => ma.Liker)
                .WithMany(u => u.MatchActionsTo)
                .HasForeignKey(ma => ma.LikerID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<MatchAction>()
                .HasOne(m => m.Liked)
                .WithMany(u => u.MatchActionsFrom)
                .HasForeignKey(m => m.LikedID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<MatchAction>()
                .HasKey(ma => new
                {
                    ma.LikerID,
                    ma.LikedID
                });
        }
    }
}