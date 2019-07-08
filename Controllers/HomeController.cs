using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        // Display the form to add quote
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        // Post Method for inserting to db
        [HttpPost("create")]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO users (Name, Quote) VALUES ('{user.Name}', '{user.Quote}')";
                DbConnector.Execute(query);
                return RedirectToAction("Show", user);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("quotes")]
        public IActionResult Show()
        {
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users");
            ViewBag.AllUsers = AllUsers;
            return View("Show");
        }
    }
}
