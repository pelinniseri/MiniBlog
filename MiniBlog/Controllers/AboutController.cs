using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBlog.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager();
        public ActionResult Index()
        {
            var aboutcontent = abm.GetAll();
            
            return View(aboutcontent);
        }

        public PartialViewResult Footer()
        {
            
            var aboutconetentlist=abm.GetAll();
            return PartialView(aboutconetentlist);
        }

        public PartialViewResult MeetTheTeam()
        {
            AuthorManager autman = new AuthorManager();
            var authlist = autman.GetAll();
            return PartialView(authlist);
        }
    }
}