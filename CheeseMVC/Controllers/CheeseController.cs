using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        static Dictionary<string, string> Cheeses = new Dictionary<string, string>();

        public IActionResult Index()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string description)
        {
            Cheeses[name] = description;
            return Redirect("/Cheese");
        }

        [HttpGet]
        ///<summary>Show the remove form (using select box)</summary>
        public IActionResult Remove()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Remove")]
        /// <summary>Remove one cheese at a time. </summary>
        public IActionResult RemoveCheese(string removedCheese)
        {
            if (String.IsNullOrEmpty(removedCheese))
            {
                ViewBag.error = "Please select a cheese";
                ViewBag.cheeses = Cheeses;
                return View("Remove");
            }
            Cheeses.Remove(removedCheese);
            return Redirect("/Cheese");
        }
    }
}