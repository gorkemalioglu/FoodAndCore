using FoodAndCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodAndCore.ViewComponents
{
    public class CategoryGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
                CategoryRepository categoryRepository = new CategoryRepository();
                var categorylist = categoryRepository.TList();
                return View(categorylist);

        }
    }
}
