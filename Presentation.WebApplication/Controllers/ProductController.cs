using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application;

namespace Presentation.WebApplication.Controllers
{
    public class ProductController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var shop = new ShopService();
            var products = shop.GetAllProducts();
            return View(products);
        }
        [Authorize(Roles ="admin")]
        public IActionResult Add(/*Shop.Domain.Model.Product.Product product*/)
        {
            return Content("added");
        }
    }
}
