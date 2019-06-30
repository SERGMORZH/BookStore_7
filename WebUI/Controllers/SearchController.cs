using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
namespace WebUI.Controllers
{
    public class SearchController : Controller
    {
        IBookRepository repository;
        // GET: Search
        public SearchController(IBookRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Поиск по автору";

            return View();
        }

        [HttpPost]
        public ActionResult BookSearch(string name)
        {
            
            var allbooks = repository.Books.Where(a => a.Author.Contains(name)).ToList();

            if (allbooks.Count <= 0)
            {
                return HttpNotFound();
            }

            return PartialView(allbooks);
            
        }
    }
}