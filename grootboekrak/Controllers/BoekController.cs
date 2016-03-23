using System;
using System.Web.Mvc;
using grootboekrak.domain;
using grootboekrak.Models;
using grootboekrak.repository;

namespace grootboekrak.Controllers
{
    public class BoekController : Controller
    {
        public ActionResult Index()
        {
            using (var bookRepo = new BookRepository())
            {
                var books = bookRepo.GetMany();

                var model = BookIndexModel.FromDomain(books);
                return View(model);
            }
        }
        public ActionResult Add()
        {
            return View();
        }
        public JsonResult Create(CreateBookModel model)
        {
            var book = model.ToDomain();
            using (var bookRepo = new BookRepository())
            {
                bookRepo.Create(book);
            }

            return new JsonResult{Data = new{IsOk = true}};
        }

        public JsonResult Update(BookModel model)
        {

            var book = model.ToDomain();
            using (var bookRepo = new BookRepository())
            {
                bookRepo.Update(book);
            }

            return new JsonResult { Data = new { IsOk = true } };
            
        }

        public ActionResult Delete(int id)
        {
          
            using (var bookRepo = new BookRepository())
            {
                bookRepo.Delete(id);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            using (var bookRepo = new BookRepository())
            {
                var book = bookRepo.Get(id);

                var model = BookModel.FromDomain(book);

            return View(model);

            }
        }
        
    }
}