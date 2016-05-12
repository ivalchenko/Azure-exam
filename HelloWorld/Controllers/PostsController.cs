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
    public class PostsController : Controller
    {
       private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.Include(s=>s.Tags).ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int postId = (int)id;
            PostComment postComment = new PostComment();
            postComment.Post = db.Posts.Find(id);
            postComment.Comments = db.Comments.Where(s => s.Post.PostId == postId).ToList();
            
            ViewBag.CurrentUserId = User.Identity.GetUserId();

            /*if (postComment.Post.Tags != null && postComment.Post.Tags.Count > 0)
                ViewBag.Tags = postComment.Post.Tags.ToList();
            ViewBag.Tags = null;*/

            //ViewBag.Tags = db.Tags.Where(s => s.Posts.)

            if (postComment == null)
            {
                return HttpNotFound();
            }
            return View(postComment);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            CreatePostView model = new CreatePostView();
            model.TagList = new SelectList(db.Tags);
            
            return View(model);
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePostView post, string[] CategoryId)
        {
            Post currPost = new Post {  
                                       Title = post.Title, 
                                       Description = post.Description, 
                                       PostDate = DateTime.Now, 
                                       Tags = null,
                                       CommentsNumber = 0,
                                       LikesNumber = 0
                                       //LikeUserId = new List<string>()
                                     };

                List<Tag> tags = new List<Tag>();

                if(CategoryId != null)
                {
                    foreach (string tagName in CategoryId)
                    {
                        tags.Add(db.Tags.First(s => s.TagName.Equals(tagName)));
                    }
                }                

                currPost.Tags = tags;
                db.Posts.Add(currPost);
                db.SaveChanges();
                return RedirectToAction("Index", "Posts");
        }

        // GET: Posts/ByTag/tagName
        public ActionResult ByTag(string tagName)
        {
            List<Post> Posts = new List<Post>();

            foreach (var post in db.Posts.Include(s => s.Tags).ToList())
            {
                if (post.Tags != null && post.Tags.Count > 0)
                {
                    foreach (var tag in post.Tags)
                    {
                        if (tag.TagName.Equals(tagName))
                            Posts.Add(post);
                    }
                }
            }

            return View("Index", Posts);
        }
        
        //POST Like
        [HttpPost]
        //[Authorize]
        public ActionResult AJAXLike(int postId)
        {
            db.Posts.Find(postId).LikesNumber += 1;
            db.SaveChanges();
            var likesNumber = db.Posts.Find(postId).LikesNumber;

            return Json(likesNumber);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditPostView model = new EditPostView();
            Post post = db.Posts.Find(id);
            model.Description = post.Description;
            model.PostId = post.PostId;
            model.Title = post.Title;
            model.LikesNumber = post.LikesNumber;
            model.CommentsNumber = post.CommentsNumber;
            model.Comments = null;
            model.TagList = new SelectList(db.Tags);
           
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);

        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditPostView model, string[] CategoryId)
        {
            if (ModelState.IsValid)
            {
               Post EditedPost = new Post {  
                                       PostId = model.PostId,
                                       Title = model.Title, 
                                       Description = model.Description, 
                                       PostDate = DateTime.Now, 
                                       Tags = null,
                                       CommentsNumber = db.Comments.Where(s => s.Post.PostId == model.PostId).ToList().Count(),
                                       Comments = db.Comments.Where(s => s.Post.PostId == model.PostId).ToList(),
                                       LikesNumber = model.LikesNumber
                                     };

                

               if (CategoryId != null)
               {
                   List<Tag> tags = new List<Tag>();
                   foreach (string tagName in CategoryId)
                   {
                       tags.Add(db.Tags.First(s => s.TagName.Equals(tagName)));
                   }
                   EditedPost.Tags = tags;
               }

               //db.Posts.Add(EditedPost);
               db.Entry(EditedPost).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("Index", "Posts");
            }
            return RedirectToAction("Index", "Posts");
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);

            List<Comment> DeleteCommentsList = db.Comments.Where(s => s.Post.PostId == id).ToList();
            foreach(var comment in DeleteCommentsList)
            {
                db.Comments.Remove(comment);
                db.SaveChanges();
            }

            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index", "Posts");
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
