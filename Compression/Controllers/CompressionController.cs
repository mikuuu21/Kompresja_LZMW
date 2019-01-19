using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Compression.Controllers
{
    public class CompressionController : Controller
    {
        // GET: HelloWorld
        public ActionResult StartView()
        {
            return View();
        }


        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }

    }
}