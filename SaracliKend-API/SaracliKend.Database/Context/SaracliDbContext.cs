using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaracliKend.Domain.Entities;
using File = SaracliKend.Domain.Entities.File;

namespace SaracliKend.Database.Context;

public class SaracliDbContext : IdentityDbContext<User>
{
    public SaracliDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person>? People { get; set; }
    public DbSet<School>? Schools { get; set; }
    public DbSet<Legend>? Legends { get; set; }
    public DbSet<Poetry>? Poetries { get; set; }
    public DbSet<FunnyStory>? FunnyStories { get; set; }
    public DbSet<SliderImage>? SliderImages { get; set; }
    public DbSet<Location>? Locations { get; set; }
    public DbSet<Information>? Information { get; set; }
    public DbSet<InformationImage>? InformationImages { get; set; }
    public DbSet<File>? Files { get; set; }
    public DbSet<News>? News { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Person>().HasKey(m => m.Id);
        builder.Entity<School>().HasKey(m => m.Id);
        builder.Entity<Teacher>().HasKey(m => m.Id);
        builder.Entity<Legend>().HasKey(m => m.Id);
        builder.Entity<Poetry>().HasKey(m => m.Id);
        builder.Entity<FunnyStory>().HasKey(m => m.Id);
        builder.Entity<SliderImage>().HasKey(m => m.Id);
        builder.Entity<Location>().HasKey(m => m.Id);
        builder.Entity<Information>().HasKey(m => m.Id);
        builder.Entity<InformationImage>().HasKey(m => m.Id);
        builder.Entity<File>().HasKey(m => m.Id);
        builder.Entity<News>().HasKey(m => m.Id);

        base.OnModelCreating(builder);
    }
}
