using DataAccessLayer.Concrete;
using MiniBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBlog.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public List<ChartBlog> BlogList()
        {
            List<ChartBlog> chartBlogs = new List<ChartBlog>();
            using(var chart=new Context())
            {
                chartBlogs = chart.Blogs.Select(x => new ChartBlog
                {
                    BlogName = x.BlogTitle,
                    RatingBlog = x.BlogRating
                }).ToList();
            }
            return chartBlogs;
        }
        public ActionResult VisualizeResult()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Chart1()
        {
            return View();
        }
    }
}