using DictionaryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DictionaryWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private DictionaryContext _db = new DictionaryContext();

        public ActionResult Index(string searchTerm)
        {
            ViewBag.Title = "Dictionary-Home Page";
            var word = _db.Words.Where(w => w.word == searchTerm).Include(w => w.Definitions);
            return View(word);
        }
    }
}
