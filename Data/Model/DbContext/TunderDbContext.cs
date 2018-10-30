using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Model.DbContext
{
    public class TunderDbContext : Microsoft.EntityFrameworkCore.DbContext, ITunderDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MatchAction> MatchActions { get; set; }
        public DbSet<UserMatch> Matches { get; set; }

        public TunderDbContext(DbContextOptions<TunderDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region UserMatch
            modelBuilder.Entity<UserMatch>()
                .HasKey(um => new { um.UserId, um.MatchId });

            modelBuilder.Entity<UserMatch>()
                .HasOne(um => um.User)
                .WithMany(u => u.Matches)
                .HasForeignKey(um => um.UserId);

            modelBuilder.Entity<UserMatch>()
                   .HasOne(um => um.Match)
                   .WithMany(m => m.MatchesUsers)
                   .HasForeignKey(um => um.MatchId);
            #endregion

            #region MatchAction
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
            #endregion
        }
    }
}