using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MiniBlog.Controllers
{
    
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager userProfileManager = new UserProfileManager();
        BlogManager bm = new BlogManager();
        Context c = new Context();
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            var adsoyad = c.Authors.Where(x => x.Mail == mail).Select(y => y.AuthorName).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            var image = c.Authors.Where(x => x.Mail == mail).Select(y => y.AuthorImage).FirstOrDefault();
            ViewBag.image = image;
            return View();
        }
        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];
            var profileValues = userProfileManager.GetAuthorByMail(p);
            return PartialView(profileValues);
        }

        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = userProfileManager.GetBlogByAuthor(id);
            return View(blogs);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blogs = bm.FindBlog(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            //List<SelectListItem> valuesAuthor = (from y in c.Authors.ToList()
            //                                     select new SelectListItem
            //                                     {
            //                                         Text = y.AuthorName,
            //                                         Value = y.AuthorID.ToString()
            //                                     }).ToList();
            var yazarMail = (string)Session["Mail"];
            var yazarAd = c.Authors.Where(x => x.Mail == yazarMail).Select(y => y.AuthorName).FirstOrDefault();
            ViewBag.values = values;
            ViewBag.values2 = yazarAd;

            return View(blogs);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog b)
        {
            bm.UpdateBlog(b);
            return RedirectToAction("BlogList");
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {

            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            //List<SelectListItem> valuesAuthor = (from y in c.Authors.ToList()
            //                                     select new SelectListItem
            //                                     {
            //                                         Text = y.AuthorName,
            //                                         Value = y.AuthorID.ToString()
            //                                     }).ToList();

            var yazarMail = (string)Session["Mail"];
            var yazarAd = c.Authors.Where(x => x.Mail == yazarMail).Select(y => y.AuthorName).FirstOrDefault();

            ViewBag.values = values;
            ViewBag.values2 = yazarAd;

            return View();
        }

        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.BlogAddBL(b);

            return RedirectToAction("BlogList");
        }

        public ActionResult UpdateUserProfile(Author p)
        {
            userProfileManager.EditAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }

    }
}