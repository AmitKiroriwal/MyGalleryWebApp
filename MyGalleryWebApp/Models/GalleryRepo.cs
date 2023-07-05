using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;


namespace MyGalleryWebApp.Models
{
    public class GalleryRepo:IGalleryRepo
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public GalleryRepo(AppDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            this._context = context;  //DI
        }

        public async Task<Gallery> AddGallery(Gallery gallery)
        {
            _context.galleries.Add(gallery);
           
            _context.SaveChanges();
            
            return gallery;
        }

        

        public GalCategory GetById(int id)
        {
            return _context.galleryCategories.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<GalCategory> GetCategories()
        {
            return _context.galleryCategories.ToList();
        }

        public List<Gallery> GetGalleries()
        {
            return _context.galleries.ToList();
        }

        public List<Gallery> GetGalleryById(int id)
        {
            return _context.galleries.Where(x => x.CategoryId == id).ToList();
            
        }

        public async Task<GalCategory> InsertCategory(GalCategory category)
        {
            
            _context.galleryCategories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public async Task<IEnumerable<SelectListItem>> Category()
        {
            var data = _context.galleryCategories.Select(s => new { Name = s.Name, id = s.Id });
            var res = await data.Select(x => new SelectListItem { Text = x.Name, Value = x.id.ToString() }).ToListAsync();
            return res;
        }
        public async Task<IEnumerable<SelectListItem>> FetchName(int id)
        {
            var data = _context.galleryCategories.Where(x => x.Id == id).Select(s => new { Name = s.Name, id = s.Id });
            var res = await data.Select(x => new SelectListItem { Text = x.Name, Value = x.id.ToString() }).ToListAsync();
            return res;
        }
        
        public void UploadFile(List<IFormFile> files)
        {
            throw new NotImplementedException();
        }
        
        private string EnsureFileName (string filename)
        {
            if(filename.Contains("\\"))
            {
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);
            }
            return filename;
        }
        private string GetpathAndfilename(string filename)
        {
            string path = hostingEnvironment.WebRootPath + "\\uploads\\";
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + filename;
        }

        public Gallery DeleteGal(int id)
        {
            Gallery gallery = _context.galleries.Find(id);
            if(gallery!= null)
            {
                _context.galleries.Remove(gallery);
                _context.SaveChanges();
            }
            return gallery;
        }

        public Gallery UpdateGal(Gallery gallery)
        {
            var Gal=_context.galleries.Attach(gallery);
            Gal.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return gallery;
        }

        public GalCategory UpdateCategory(GalCategory category)
        {
            var Cat=_context.galleryCategories.Attach(category);
            Cat.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return category;
        }

        public GalCategory DeleteCategory(int id)
        {
            GalCategory category = _context.galleryCategories.Find(id);
            if(category!=null)
            {
                _context.galleryCategories.Remove(category);
                _context.SaveChanges();

            }
            return category;
        }

        public Gallery GalleryById(int id)
        {
            return _context.galleries.FirstOrDefault(x => x.Id == id);
        }
    }
}
