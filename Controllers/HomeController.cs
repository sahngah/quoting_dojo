using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotingDojo.Factory;
using quotingDojo.Models;
using Microsoft.AspNetCore.Http;

namespace quotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserFactory userFactory;
        public HomeController()
        {
            userFactory = new UserFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = "";
            HttpContext.Session.Clear();
            return View();
        }
        [HttpPost]
        [Route("submit")]
        public IActionResult Method(string name, string quote)
        {
        User NewUser = new User
        {
            Name = name,
            Quote = quote
        };
        TryValidateModel(NewUser);
        if(ModelState.IsValid)
        {
            userFactory.Add(NewUser);
            return RedirectToAction("AllQuotes");
        }
        else{
        ViewBag.errors = ModelState.Values;
        return View("Index");
        }
        }
        [HttpGet]
        [Route("quote")]
        public IActionResult AllQuotes()
        {
            ViewBag.User = userFactory.FindAll();
            return View("quote");
        }
    }
}
