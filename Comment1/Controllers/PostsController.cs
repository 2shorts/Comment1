using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Comment1.Models;
using Microsoft.AspNet.Identity;

namespace Comment1.Controllers
{
    public class PostsController : Controller
    {
        private DBCommentsEntities db = new DBCommentsEntities();
        [Authorize]
        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
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

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,Message,PostedDate")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                post.PostedDate = DateTime.UtcNow;
                post.UserId = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,Message,PostedDate, UserId")] Post post)
        {

            if (ModelState.IsValid && post.UserId == User.Identity.Name)
            {

                var OldPost = db.Posts.AsNoTracking().Where(p => p.PostID == post.PostID).FirstOrDefault();
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                var PostsHistory = new PostsHistory();
                PostsHistory.PostID = OldPost.PostID;
                PostsHistory.Message = OldPost.Message;
                PostsHistory.UserId = OldPost.UserId;
                PostsHistory.ChangedDate = DateTime.UtcNow;
                db.Entry(PostsHistory).State = EntityState.Modified;
                
                db.PostsHistories.Add(PostsHistory);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(post);
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
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
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
