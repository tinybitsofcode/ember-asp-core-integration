using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ember_asp_test.Controllers
{
    using System.IO;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Server.Kestrel;

    public class AppController : Controller
    {
        private readonly IHostingEnvironment env;

        /// <inheritdoc />
        public AppController(IHostingEnvironment env)
        {
            this.env = env;
        }

        public IActionResult Index()
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var root = System.IO.Path.GetDirectoryName(location);

            //var root = env.WebRootPath;
            var file = Path.Combine(root, "dist", "index.html");

            var content = System.IO.File.ReadAllBytes(file);
            //using (var contents = System.IO.File.OpenRead(file))
            //{
            return File(content, "text/html");
            //}
            //return File(Server.MapPath("~/my-ember-app/dist/") + "index.html", "text/html");
        }
    }
}