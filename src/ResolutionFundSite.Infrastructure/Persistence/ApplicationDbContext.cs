using Microsoft.EntityFrameworkCore;
using ResolutionFundSite.Domain.Entities;

namespace ResolutionFundSite.Infrastructure.Persistence;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}