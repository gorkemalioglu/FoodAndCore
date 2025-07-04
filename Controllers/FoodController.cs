using FoodAndCore.Data.Models;
using FoodAndCore.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList.Extensions;

namespace FoodAndCore.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context c = new Context();
        public IActionResult Index(int page =1)
        {
           
            return View(foodRepository.TList("Category").ToPagedList(page,3));
        }
        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values =(from x in c.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value=x.Id.ToString()
                                          }).ToList();
            ViewBag.v1=values;
            return View();
        }
        [HttpPost]
        public IActionResult AddFood(urunekle p)
        {
            Food f = new Food();
            if (p.ImageURL != null)
            {
                var extension=Path.GetExtension(p.ImageURL.FileName);
                var newimagename=Guid.NewGuid() + extension;
                var location=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/resimler/",newimagename);
                var stream= new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                f.ImageURL = newimagename;
            }
            f.Name = p.Name;
            f.Price= p.Price;
            f.Stock= p.Stock;
            f.CategoryId= p.CategoryId;
            //f.Description= p.Description;
            foodRepository.TAdd(f);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFood(int id)
        {
            foodRepository.TDelete(new Food { Id=id});
            return RedirectToAction("Index");
        }
        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.Name,
                                               Value = y.Id.ToString()
                                           }).ToList();
            ViewBag.v1 = values;

            Food f = new Food()
            {
                Id=x.Id,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImageURL = x.ImageURL
            };
            return View(f);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = foodRepository.TGet(p.Id);
            x.Name = p.Name;
            x.Stock= p.Stock;
            x.Price= p.Price;
            x.ImageURL= p.ImageURL;
            x.Description= p.Description;
            x.CategoryId= p.CategoryId;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
