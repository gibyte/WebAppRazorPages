using Microsoft.EntityFrameworkCore;
using System;
using WebAppRazorPages.Model;

namespace WebAppRazorPages.Controller
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User>? Users { get; set; }
    }
}
