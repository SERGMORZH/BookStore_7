﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
namespace WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IBookRepository repository;
        public HomeController(IBookRepository repo)
        {
            repository = repo;
        }
       
        public ActionResult Index()
        {
            ViewBag.Title = "Администратор";

            return View();
        }

       
    }
}
   