using Microsoft.EntityFrameworkCore;
using MyGalleryWebApp.Models;
namespace MyGalleryWebApp.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GalCategory>().HasData(new GalCategory()
            //{
            //    Id = 1,
            //    Name = "Flower",
            //    CoverImage="user.png"

            //},
            //new GalCategory() { Id = 2, Name = "Nature", CoverImage="user.png"}
            //);
        }
    }
}
