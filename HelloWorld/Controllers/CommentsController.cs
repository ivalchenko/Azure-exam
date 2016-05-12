using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;
using Microsoft.AspNet.Identity;

namespace HelloWorld.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // POST: Comments/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment, int? PostId, HttpPostedFileBase file, bool Visible)
        {
            if (ModelState.IsValid)
            {
                comment.AuthorId = User.Identity.GetUserId();
                comment.AuthorName = User.Identity.Name;
                comment.IsVisible = !Visible;
                Post post = db.Posts.Find(PostId);
                comment.CommentDate = DateTime.Now;
                comment.Post = post;
                db.Posts.Find(comment.Post.PostId).CommentsNumber += 1;

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = file.FileName;
                    string newFileName = Guid.NewGuid().ToString() + fileName;
                    file.SaveAs(HttpContext.Server.MapPath("~/Content/img/") + newFileName);
                    comment.ImagePath = newFileName;
                }

                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Details", "Posts", new { id = comment.Post.PostId });
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            var postId = db.Comments.Include(s => s.Post).FirstOrDefault(s => s.CommentId == id).Post.PostId;
            db.Comments.Remove(comment);
            db.Posts.Find(postId).CommentsNumber -= 1;
            db.SaveChanges();
            return RedirectToAction("Details", "Posts", new { id = postId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
