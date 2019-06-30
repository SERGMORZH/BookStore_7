using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Entities;
using Domain.Concrete;
using System.Data;
using System.Web.Http.Cors;

namespace WebUI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        BookContext db = new BookContext();

        public IEnumerable<Book> GetBooks()
        {
            return db.Books; 
        }

        public Book GetBook(int id)
        {
            Book book = db.Books.Find(id);
            return book;
        }

        [HttpPost]
        public void CreateBook([FromBody]Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditBook(int id, [FromBody]Book book)
        {
            if (id == book.BookId)
            {
                db.Entry(book).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}