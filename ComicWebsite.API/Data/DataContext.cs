using ComicWebsite.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicWebsite.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set;}
        public DbSet<Comic> Comics {get; set;}
        public DbSet<Like> Likes{ get; set;}

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
            //builder.Entity<Like>().HasKey(k => new {k.LikerId, k.LikedId});

            // builder.Entity<Like>().HasOne(u => u.Liked).WithMany(u => u.Likers).HasForeignKey(u =>u.LikedId).OnDelete(DeleteBehavior.Restrict);
            ///builder.Entity<//Like>().HasOne(u => u.Liker).WithMany(u => u.Likeds).HasForeignKey(u =>u.LikerId).OnDelete(DeleteBehavior.Restrict);
        // }

    }
}