using Microsoft.AspNetCore.Mvc;
using MyGalleryWebApp.Models;
using System.Diagnostics;

namespace MyGalleryWebApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IGalleryRepo _galleryRepo;
        private readonly IWebHostEnvironment env;

        public HomeController(IGalleryRepo galleryRepo, IWebHostEnvironment env)
        {
            //_logger = logger;
            this._galleryRepo = galleryRepo;
            this.env = env;
        }

        public IActionResult Index()
        {
          var model=  _galleryRepo.GetCategories();
            return View(model);
        }
        public IActionResult Gallery(int id)
        {
            var model = _galleryRepo.GetGalleryById(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.PageTitle = "Create Gallery";
           
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(GalleryViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqeFileName = null;

                if (model.Photo != null)
                {
                    string upload = Path.Combine(env.WebRootPath, "Images");
                    uniqeFileName = Guid.NewGuid().ToString() + "-" + model.Photo.FileName;
                    string photopath = Path.Combine(upload, uniqeFileName);
                    model.Photo.CopyTo(new FileStream(photopath, FileMode.Create));
                }
                GalCategory category = new GalCategory()
                {
                    Name = model.Category,
                    CoverImage = uniqeFileName
                };
           
                await _galleryRepo.InsertCategory(category);
                return RedirectToAction("Index");
                    
            }

            return View();

        }

        public async Task<IActionResult> AddGallery()
        {
            ViewBag.PageTitle = "Add Gallery Images";
            ViewBag.category = await _galleryRepo.Category();
            
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGallery(PhotoGallery model)
        {
            if (ModelState.IsValid)
            {
                string uniqeFileName = null;

                if (model.Photos != null)
                {
                    foreach (var photo in model.Photos)
                    {
                        string upload = Path.Combine(env.WebRootPath, "Images");
                        uniqeFileName = Guid.NewGuid().ToString() + "-" + photo.FileName;
                        string photopath = Path.Combine(upload, uniqeFileName);
                        photo.CopyTo(new FileStream(photopath, FileMode.Create));

                        Gallery gallery = new Gallery()
                        {

                            PhotoPath = uniqeFileName,
                            CategoryId = model.CategoryId,
                           // Categoryname = model.CategoryName.ToString()
                        };
                        await _galleryRepo.AddGallery(gallery);
                    }



                }

                return RedirectToAction("GalleryTable");

            }

            return View();

        }
        public async Task<IActionResult> FetchName(int id)
        {
            var dis = await _galleryRepo.FetchName(id);
            return Json(dis);
        }
        public IActionResult GalleryTable()
        {
            var model = _galleryRepo.GetGalleries();
            return View(model);
        }
        public IActionResult GalleryUpload()
        {
            return View();
        }

        public IActionResult DeleteGal(int id)
        {
            if(id==null||id==0)
            {
                return NotFound();
            }
            var galid = _galleryRepo.GetGalleries();
            var delid=galid.FirstOrDefault(x=>x.Id==id);
            if(delid!=null)
            {
                _galleryRepo.DeleteGal(delid.Id);
                return RedirectToAction("GalleryTable");
            }
            return View();
        }

        public IActionResult UpdateGal(int id)
        {
            var gal = _galleryRepo.GalleryById(id);
            return View(gal);
        }
        [HttpPost]

        public IActionResult UpdateGal(Gallery gallery)
        {
            if(ModelState.IsValid)
            {
                var gal = _galleryRepo.GalleryById(gallery.Id);
                if(gal!=null)
                {
                    gal.Categoryname=gallery.Categoryname;
                    gal.CategoryId=gallery.CategoryId;
                    gal.PhotoPath=gallery.PhotoPath;
                }
                _galleryRepo.UpdateGal(gal);
                return RedirectToAction("GalleryTable");
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}