using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace tunder.Model.DbContext
{
    public interface ITunderDbContext 
    {
        DbSet<User> Users { get; set; }
    }
}