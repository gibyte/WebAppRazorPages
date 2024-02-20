using Microsoft.EntityFrameworkCore;
using System;
using WebAppRazorPages.Model;
using WebAppRazorPages.Model.AuthApp;

namespace WebAppRazorPages.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Student>? Students { get; set; }
        public DbSet<AuthUser>? AuthUsers { get; set; }
    }
}
