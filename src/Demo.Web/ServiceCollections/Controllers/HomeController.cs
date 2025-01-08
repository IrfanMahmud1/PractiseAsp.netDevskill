using Microsoft.AspNetCore.Mvc;
using ServiceCollections.Models;
using System.Diagnostics;

namespace ServiceCollections.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItem _item;
        private readonly IProduct _product;
        public HomeController(ILogger<HomeController> logger, IItem item, [FromKeyedServices("Product2")] IProduct product)
        {
            _logger = logger;
            _item = item;
            _product = product;
        }

        public IActionResult Index()
        {
            var amount = _item.GetAmount();
            var pro1 = _product.GetQuantity();
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
