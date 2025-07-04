using FoodAndCore.Data.Models;
using FoodAndCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FoodAndCore.ViewComponents
{
    public class FoodListByCategory : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            FoodRepository foodRepository = new FoodRepository();
            CategoryRepository categoryRepository = new CategoryRepository();

            var category = categoryRepository.List(x => x.Id == id).FirstOrDefault();
            if (category != null && category.Status == false)
            {
                
                return View(new List<Food>());
            }

            var foodlist = foodRepository.List(x => x.CategoryId == id);
            return View(foodlist);
        }
    }
}
