using Microsoft.AspNetCore.Mvc;
using fa19projectgroup16.Utilities;
using System;
using fa19projectgroup16.DAL;
using fa19projectgroup16.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fa19projectgroup16.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Accounts");
            }
            else
            {
                return View();
            }
        }
    }
}
