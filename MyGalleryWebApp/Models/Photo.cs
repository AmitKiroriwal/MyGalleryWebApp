namespace MyGalleryWebApp.Models
{
    public class Photo
    {
        public List<IFormFile> Photos { get; set; }
        public IFormFile coverImage { get; set; }
    }
}
