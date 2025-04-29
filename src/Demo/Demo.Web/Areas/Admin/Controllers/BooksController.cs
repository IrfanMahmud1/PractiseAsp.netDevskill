using Demo.Application.Features.Books.Commands;
using Demo.Web.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BooksController : Controller
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            var model = new BookAddCommand();
            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BookAddCommand model)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(model);
            }
            return View(model);
        }
    }
}
