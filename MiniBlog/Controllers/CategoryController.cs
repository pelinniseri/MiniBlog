using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBlog.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager cm = new CategoryManager();
     
        public ActionResult Index()
        {
            var categoryValues = cm.GetAll();
            return View(categoryValues);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = cm.GetAll();
            return PartialView(categoryValues);
        }
        public ActionResult AdminCategoryList()
        {
            var categorylist = cm.GetAll();
            return View(categorylist);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            cm.CategoryAddBL(p);
            return RedirectToAction("AdminCategoryList");
        }
        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {

            Category category = cm.FindCategory(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category p)
        {
            cm.EditCategory(p);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryDelete(int id)
        {
            cm.DeleteCategoryBL(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryStatusTrue(int id)
        {
            cm.ActiveCategoryBL(id);
            return RedirectToAction("AdminCategoryList");
        }
       
    }
}