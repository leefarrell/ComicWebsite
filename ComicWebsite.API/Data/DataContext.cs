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
    }
}