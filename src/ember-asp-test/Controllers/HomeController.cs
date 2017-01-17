using Microsoft.AspNetCore.Mvc;

namespace ember_asp_test.Controllers
{
    using System.IO;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var root = System.IO.Path.GetDirectoryName(location);
            var file = Path.Combine(root, "dist", "index.html");

            var content = System.IO.File.ReadAllBytes(file);
            return File(content, "text/html");
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
