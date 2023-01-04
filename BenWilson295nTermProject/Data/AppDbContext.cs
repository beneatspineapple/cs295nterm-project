using BenWilson295nTermProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BenWilson295nTermProject
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Post> ForumPosts { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Board> Boards { get; set; }
    }
}
