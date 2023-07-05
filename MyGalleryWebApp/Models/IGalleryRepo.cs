using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyGalleryWebApp.Models
{
    public interface IGalleryRepo
    {
        List<GalCategory> GetCategories();
        GalCategory GetById(int id);
        public Gallery GalleryById(int id);
        List<Gallery> GetGalleries();
        public Task<Gallery> AddGallery(Gallery gallery);
        public Gallery DeleteGal(int id);
        public Gallery UpdateGal(Gallery gallery);
       
        public  void UploadFile(List<IFormFile> files);
        
        public  Task<IEnumerable<SelectListItem>> FetchName(int id);
        public Task<IEnumerable<SelectListItem>> Category();
        Task<GalCategory> InsertCategory(GalCategory category);
        public GalCategory UpdateCategory(GalCategory category);
        public GalCategory DeleteCategory(int id);
        List<Gallery> GetGalleryById(int id);
    }
}
