using Microsoft.AspNetCore.Mvc;
using CoffeeShopProducts.Models;


namespace CoffeeShopProducts.Controllers
{
    public class ProductController : Controller
    {
        private CoffeeShopDBContext context = new CoffeeShopDBContext();
        
        public IActionResult pIndex()
        {
            List<Product> result = context.Products.GroupBy(p => p.Category).Select(p => p.First()).ToList();
            //List<Product> result = context.Products.DistinctBy(p => p.Category).ToList();
            return View(result);
        }
        public IActionResult Detail(int itemId)
        {
            Product p = context.Products.FirstOrDefault(p => p.Id == itemId);
            return View(p);
        }

        public IActionResult Category(string category)
        {
            List<Product> result = context.Products.Where(p => p.Category == category).ToList();
            return View(result);
        }

    }
}
