namespace MyGalleryWebApp.Models
{
    public class GalleryViewModel
    {
        GalCategory galCategory =new GalCategory();
        Gallery gallery = new Gallery();
        public int Id { get; set; }
        public string Category { get; set; }

        public IFormFile Photo { get; set; }
        
    }
}
