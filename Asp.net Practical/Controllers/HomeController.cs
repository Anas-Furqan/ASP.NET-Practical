using Asp.net_Practical.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Asp.net_Practical.Controllers
{
    public class HomeController : Controller
    {
        private readonly SolutionDbContext _dbContext;
        private readonly IWebHostEnvironment _webHost;

        public HomeController(SolutionDbContext dbContext, IWebHostEnvironment webHost)
        {
            _dbContext = dbContext;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            return View();
        }


        // CATEGORY
        public IActionResult ViewCategory()
        {
            var catData = _dbContext.Categories.ToList();
            return View(catData);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category cat)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(cat);
                _dbContext.SaveChanges();
                return RedirectToAction("ViewCategory");
            }
            return View();
        }

        public IActionResult UpdateCategory(int id)
        {
            var catData = _dbContext.Categories.Find(id);
            return View(catData);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category cat)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(cat);
                _dbContext.SaveChanges();
                return RedirectToAction("ViewCategory");
            }
            return View();
        }

        public IActionResult DetailsCategory(int id)
        {
            var catData = _dbContext.Categories.Find(id);
            return View(catData);
        }

        public IActionResult DeleteCategory(int id)
        {
            var catData = _dbContext.Categories.Find(id);
            return View(catData);
        }

        [HttpPost, ActionName("DeleteCategory")]
        public IActionResult DeleteCategoryConfirmed(int id)
        {
            var catData = _dbContext.Categories.Find(id);
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Remove(catData);
                _dbContext.SaveChanges();
                return RedirectToAction("ViewCategory");
            }
            return View();
        }


        // PRODUCT 

        public IActionResult ViewProduct()
        {
            var prodData = _dbContext.Products.ToList();
            return View(prodData);
        }

        public IActionResult CreateProduct()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductVM vm, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string filename = String.Empty;
                if (file != null)
                {
                    string uploadDir = Path.Combine(_webHost.WebRootPath, "ProductImages");
                    filename = Guid.NewGuid().ToString() + " - " + file.FileName;
                    string filePath = Path.Combine(uploadDir, filename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    vm.Product.ImageURL = @"\ProductImages\" + filename;
                }

                if (vm.Product.Prod_Id == 0)
                {
                    _dbContext.Products.Add(vm.Product);
                }
                _dbContext.SaveChanges();
                return RedirectToAction("ViewProduct");
            }
            return View();
        }

        public IActionResult UpdateProduct(int id)
        {
            var prodData = _dbContext.Products.Find(id);
            return View(prodData);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product prod)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(prod);
                _dbContext.SaveChanges();
                return RedirectToAction("ViewProduct");
            }
            return View();
        }

        public IActionResult DetailsProduct(int id)
        {
            var prodData = _dbContext.Products.Find(id);
            return View(prodData);
        }

        public IActionResult DeleteProduct(int id)
        {
            var prodData = _dbContext.Products.Find(id);
            return View(prodData);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public IActionResult DeleteProductConfirmed(int id)
        {
            var prodData = _dbContext.Products.Find(id);
            if (ModelState.IsValid)
            {
                _dbContext.Products.Remove(prodData);
                _dbContext.SaveChanges();
                return RedirectToAction("ViewProduct");
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
