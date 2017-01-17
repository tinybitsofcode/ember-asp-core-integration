using Microsoft.AspNetCore.Mvc;

namespace ember_asp_test.Controllers
{
    using System.IO;

    public class AppController : Controller
    {
        public IActionResult Index()
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var root = System.IO.Path.GetDirectoryName(location);
            var file = Path.Combine(root, "dist", "index.html");

            var content = System.IO.File.ReadAllBytes(file);
            return File(content, "text/html");
        }
    }
}