using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleBlogCore.Data.Models;

namespace SimpleBlogCore.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<EmailModel> EmailModels { get; set; }
        public DbSet<ContactModel> Contact { get; set; }
        public DbSet<SettingsModel> Settings { get; set; }
    }
}