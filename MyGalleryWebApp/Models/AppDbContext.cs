using Microsoft.EntityFrameworkCore;

namespace MyGalleryWebApp.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Seed();
        //}
        public DbSet<Gallery> galleries { get; set; }
        public DbSet<GalCategory> galleryCategories { get; set; }
    }
}
