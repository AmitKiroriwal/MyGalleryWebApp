namespace MyGalleryWebApp.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; }
        public int CategoryId { get; set; }
        public string? Categoryname { get; set; }
        //public GalCategory GalCategory { get; set; } = new GalCategory();
    }
}
