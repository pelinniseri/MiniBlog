using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniBlog.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager cm = new CommentManager();

        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentlist = cm.CommentByBlog(id);
            
            return PartialView(commentlist);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            c.CommentStatus = true;
            cm.CommentAdd(c);
            return PartialView();
        }
        public ActionResult AdminCommentListTrue()
        {
            var commentlist = cm.CommentListTrue();
            return View(commentlist);
        }
        public ActionResult AdminCommentListFalse()
        {
            var commentlist = cm.CommentListFalse();
            return View(commentlist);
        }
        public ActionResult CommentStatusChangeToFalse(int id)
        {
            cm.ChangeCommentStatusToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }
        public ActionResult CommentStatusChangeToTrue(int id)
        {
            cm.ChangeCommentStatusToTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }

    }
}