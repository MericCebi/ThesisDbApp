using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThesisDbApp.Models;
using ThesisDbApp.Areas.Identity.Data;
namespace ThesisDbApp.Data;
public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Thesis> Thesis { get; set; }
    public DbSet<Chair> Chair { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
        AppUser user;

        user = new AppUser() { Id = Guid.NewGuid().ToString(), UserName = "admin@abc.com", Email = "admin@abc.com", ChairId = 2 };
        user.NormalizedUserName = user.UserName.ToUpper();
        user.NormalizedEmail = user.Email.ToUpper();
        user.PasswordHash = hasher.HashPassword(user, "Admin*123");
        builder.Entity<AppUser>().HasData(user);

        base.OnModelCreating(builder);
        IdentityRole role = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Administrator" };
        role.NormalizedName = role.Name.ToUpper();
        builder.Entity<IdentityRole>().HasData(role);

        IdentityUserRole<string> ur = new IdentityUserRole<string>() { UserId = user.Id, RoleId = role.Id };
    }
    public DbSet<ThesisDbApp.Models.User> User { get; set; }
}
