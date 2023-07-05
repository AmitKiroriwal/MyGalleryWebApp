namespace MyGalleryWebApp.Models
{
    public class PhotoGallery
    {
        GalCategory galCategory=new GalCategory();
        Gallery Gallery=new Gallery();
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
