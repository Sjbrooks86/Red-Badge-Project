using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeProject.Controllers
{
    public class MovieController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = new MovieListItem[0];
            return View(model);
        }
    }
}
