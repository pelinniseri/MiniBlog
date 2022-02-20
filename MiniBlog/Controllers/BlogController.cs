using BusinessLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;

namespace MiniBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        BlogManager bm = new BlogManager();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page=1)
        {
            var bloglist = bm.GetAll().ToPagedList(page,6);
            return PartialView(bloglist);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {
            //1. post
            var posttitle1 = bm.GetAll().OrderByDescending(z=> z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var postdate1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var bloglink1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 1).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.postdate1 = postdate1;
            ViewBag.postlink1 = bloglink1;

            //2.post

            var posttitle2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postdate2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var bloglink2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 2).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.postdate2 = postdate2;
            ViewBag.postlink2 = bloglink2;
            //3.post

            var posttitle3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postdate3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var bloglink3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 3).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.postdate3 = postdate3;
            ViewBag.postlink3 = bloglink3;

            //4.post

            var posttitle4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postdate4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var bloglink4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 4).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.postdate4 = postdate4;
            ViewBag.postlink4= bloglink4;


            //5.post

            var posttitle5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            var postdate5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            var bloglink5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryID == 5).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.postdate5 = postdate5;
            ViewBag.postlink5 = bloglink5;

            return PartialView();
        }
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }


        [AllowAnonymous]
        public ActionResult BlogDetails()
        {

            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }

        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var blogListByCat = bm.GetBlogByCategory(id);
            var blogname = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            var blogaciklama= bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.blogname = blogname;
            ViewBag.blogaciklama = blogaciklama;
            return View(blogListByCat);
        }


        public ActionResult AdminBlogList()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
        }
        public ActionResult AdminBlogList2()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
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
            List<SelectListItem> valuesAuthor = (from y in c.Authors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.AuthorName,
                                               Value = y.AuthorID.ToString()
                                           }).ToList();

            ViewBag.values = values;
            ViewBag.values2 = valuesAuthor;
            
            return View();
        }

        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.BlogAddBL(b);

            return RedirectToAction("AdminBlogList");
        }

        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBL(id);

            return RedirectToAction("AdminBlogList");
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
            List<SelectListItem> valuesAuthor = (from y in c.Authors.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = y.AuthorName,
                                                     Value = y.AuthorID.ToString()
                                                 }).ToList();

            ViewBag.values = values;
            ViewBag.values2 = valuesAuthor;
            
            return View(blogs);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog b)
        {
            bm.UpdateBlog(b);
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentlist = cm.CommentByBlog(id);

            return View(commentlist);
        }
        public ActionResult AuthorBlogList(int id)
        {
         
            var blogs = bm.GetBlogByAuthor(id);
            return View(blogs);
        }
       
    }
}