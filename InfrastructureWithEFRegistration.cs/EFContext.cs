using Domain.Common;
using Domain.Entities;
using InfrastructureWithEFRegistration.DummyData;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureWithEFRegistration;

public class EFContext : DbContext
{
    public EFContext(DbContextOptions<EFContext> options)
           : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Webinar> Webinars { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.
            ApplyConfigurationsFromAssembly
            (typeof(EFContext).Assembly);



        foreach (var item in DummyCategories.Get())
        {
            modelBuilder.Entity<Category>().HasData(item);
        }

        foreach (var item in DummyPosts.Get())
        {
            modelBuilder.Entity<Post>(b =>
            {
                b.HasData(item);
            });
        }

        foreach (var item in DummyWebinars.Get())
        {
            modelBuilder.Entity<Webinar>().HasData(item);
        }
    }
}
