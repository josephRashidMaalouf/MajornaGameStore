using MajornaGameStore.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql;

public class MajornaDbContext(DbContextOptions<MajornaDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Discount> Discounts { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<EventType> EventTypes { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductType> ProductTypes { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<Publisher> Publishers { get; set; } = null!;
    public DbSet<Developer> Developers { get; set; } = null!;
    public DbSet<Screenshot> Screenshots { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(b =>
        {
            // Each User can have many UserClaims
            b.HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            // Each User can have many UserLogins
            b.HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            b.HasMany(e => e.Tokens)
                .WithOne()
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

        });


        builder.Entity<Role>(b =>
            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired()
        );
    }
}
