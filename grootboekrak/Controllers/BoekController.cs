using System.Web.Mvc;
using grootboekrak.Models;
using grootboekrak.repository;

namespace grootboekrak.Controllers
{
    public class BoekController : Controller
    {
        public ActionResult Index()
        {
            var bookRepo = new BookRepository();
            var books = bookRepo.GetMany();

            var model = BookIndexModel.FromDomain(books);
            return View(model);
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

            return new JsonResult();
        }
    }
}