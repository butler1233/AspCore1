using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCore1.Controllers
{
    public class ShitController : Controller
    {
        // 
        // GET: /Downloads/

        public IActionResult Index()
        {
            return View();
        }

        //
        // GET: /Downloads/Welcome/

        public IActionResult Welcome(string name, double hours = 1)
        {
            ViewData["CurrentTime"] = DateTime.Now.ToString("HH:mm");
            ViewData["FutureTime"] = DateTime.Now.AddHours(hours).ToString("HH:mm");
            ViewData["Name"] = name;
            return View();
        }


    }
}
