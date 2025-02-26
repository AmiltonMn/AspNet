namespace Server.Source.Entities;

using Microsoft.EntityFrameworkCore;
using Orders;

public class ParaLancheDbContext(DbContextOptions<ParaLancheDbContext> options) : DbContext(options)
{

    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Drink> Drinks{ get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>()
            .HasMany( e => e.InvitedUsers)
            .WithOne(e => e.InvitedBy)
            .HasForeignKey(e => e.InvitedByUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<ApplicationUser>()
            .HasOne(e => e.InvitedBy)
            .WithMany(e => e.InvitedUsers)
            .HasForeignKey(e => e.InvitedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Meal>()
            .HasMany(e => e.Ingredients)
            .WithMany();

        builder.Entity<Order>()
            .HasOne(e => e.OrderedMeal)
            .WithMany();

        builder.Entity<Order>()
            .HasOne(e => e.OrderedDrink)
            .WithMany();

        builder.Entity<Review>()
            .HasOne(e => e.Drink)
            .WithMany();

        builder.Entity<Review>()
            .HasOne(e => e.Meal)
            .WithMany();

        builder.Entity<Review>()
            .HasOne(e => e.User)
            .WithMany();
    }
}