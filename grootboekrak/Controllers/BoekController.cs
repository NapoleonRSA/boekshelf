﻿using System.Web.Mvc;

namespace grootboekrak.Controllers
{
    public class BoekController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Create( string titel , string author )
        {
            return new JsonResult();
        }
    }
}