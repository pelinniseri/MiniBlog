﻿using BusinessLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

namespace MiniBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        BlogManager bm = new BlogManager();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult BlogList(int page=1)
        {
            var bloglist = bm.GetAll().ToPagedList(page,6);
            return PartialView(bloglist);
        }

        public PartialViewResult FeaturedPost()
        {
            //1. post
            var posttitle1 = bm.GetAll().OrderByDescending(z=> z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var postdate1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.postdate1 = postdate1;


            //2.post

            var posttitle2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postdate2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.postdate2 = postdate2;

            //3.post

            var posttitle3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postdate3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.postdate3 = postdate3;


            //4.post

            var posttitle4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postdate4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.postdate4 = postdate4;



            //5.post

            var posttitle5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            var postdate5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.postdate5 = postdate5;

            return PartialView();
        }
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }

      

        public ActionResult BlogDetails()
        {

            return View();
        }
        public PartialViewResult BlogCover()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.BlogByID(id);
            return PartialView(BlogDetailsList);
        }


        public ActionResult BlogByCategory()
        {
            return View();
        }
    }
}