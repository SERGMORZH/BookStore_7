
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using WebUI.Models;


namespace WebUI.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository repository;
        public int pageSize = 3;
        public BooksController(IBookRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int page = 1)
        {
            BooksListViewModel model = new BooksListViewModel();
            model.Books = repository.Books
                .Where(p => category == null || p.Category == category)
                .OrderBy(book => book.BookId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = category == null ?
        repository.Books.Count() :
        repository.Books.Where(book => book.Category == category).Count()

            };
            model.CurrentCategory = category;
            //return JsonResult

            return View(model);
        }

    }

}
