using Demo.Models;
using Demo.Models.Demo;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class DemoController : Controller
    {
        private readonly IItem _item;    

        public DemoController(IItem item)
        {
            _item = item;
        }

        public IActionResult Index()
        {
            var model = new IndexModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexModel model)
        {
            return View(model);
        }
    }
}
