using Demo.Domain.Services;
using Demo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Demo.Domain.Entities;
using Demo.Application.Exceptions;
using System.Web;
using System.Data;
using Demo.Domain;
using AutoMapper;
using Demo.Infrastructure;
using DuplicateNameException = Demo.Application.Exceptions.DuplicateNameException;
using Demo.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Demo.Web.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Roles = "Admin,HR")]
    public class AuthorsController(ILogger<AuthorsController> logger,IAuthorService authorService, IMapper mapper) : Controller
    {
        private readonly IAuthorService _authorService = authorService;
        private readonly ILogger<AuthorsController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IndexSP()
        {
            return View();
        }
        public IActionResult Add()
        {
            var model = new AddAuthorModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(AddAuthorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var author = _mapper.Map<Author>(model);
                    author.Id = IdentityGenerator.NewSequentialGuid();
                    _authorService.AddAuthor(author);
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Author Added Successfully",
                        Type = ResponseTypes.Success
                    });
                    return RedirectToAction("Index");
                }
                catch (DuplicateNameException de)
                {
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Author " + de.Message,
                        Type = ResponseTypes.Danger
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to Add Author");
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Failed to Add Author",
                        Type = ResponseTypes.Danger
                    });
                }
            }
            return View(model);
        }
        public IActionResult Update(Guid id)
        {
            var model = new UpdateAuthorModel();
            var author = _authorService.GetAuthor(id);
            _mapper.Map(author, model);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(UpdateAuthorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var author = _mapper.Map<Author>(model);
                    _authorService.UpdateAuthor(author);
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Author Updated Successfully",
                        Type = ResponseTypes.Success
                    });
                    return RedirectToAction("Index");
                }
                catch (DuplicateNameException de)
                {
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Author " + de.Message,
                        Type = ResponseTypes.Danger
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to Update Author");
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Failed to Update Author",
                        Type = ResponseTypes.Danger
                    });
                }
            }
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken,Authorize(Policy = "CustomAccess")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _authorService.DeleteAuthor(id);
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Author Deleted Successfully",
                    Type = ResponseTypes.Success
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete author");
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Failed to delete Author",
                    Type = ResponseTypes.Danger
                });
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult GetAuthorJsonData([FromBody] AuthorListModel model)
        {
            try
            {
                var (data,total,totalDisplay) = _authorService.GetAuthors(model.PageIndex , model.PageSize, model.FormatSortExpression("Name","Biography","Rating","Id"), model.Search);
                var authors = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from record in data
                            select new string[]
                    {
                        HttpUtility.HtmlEncode(record.Name),
                        HttpUtility.HtmlEncode(record.Biography),
                        record.Rating.ToString(),
                        record.Id.ToString(),
                    }).ToArray()
                };
                return Json(authors);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in getting authors");
                return Json(DataTables.EmptyResult);
            }
            
        }
        [HttpPost]
        public async Task<JsonResult> GetAuthorJsonDataSP([FromBody] AuthorListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<AuthorSearchDto>(model.SearchItem);
                var (data, total, totalDisplay) = await _authorService.GetAuthorsSPAsync(model.PageIndex, model.PageSize, model.FormatSortExpression("Name", "Biography", "Rating", "Id"), searchDto);
                var authors = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from record in data
                            select new string[]
                    {
                        HttpUtility.HtmlEncode(record.Name),
                        HttpUtility.HtmlEncode(record.Biography),
                        record.Rating.ToString(),
                        record.Id.ToString(),
                    }).ToArray()
                };
                return Json(authors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAuthorJsonData: {Message}", ex.Message);
                _logger.LogError("Error in GetAuthorJsonData: {StackTrace}", ex.StackTrace);
                return Json(DataTables.EmptyResult);
            }

        }

    }
}
