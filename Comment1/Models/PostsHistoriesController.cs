using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Comment1.Models
{
    public class PostsHistoriesController : Controller
    {
        private DBCommentsEntities db = new DBCommentsEntities();

        // GET: PostsHistories
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<PostsHistory> Postlist = db.PostsHistories.Where(p => p.PostID == id).ToList();
            if (Postlist == null)
            {
                return HttpNotFound();
            }
            return View(Postlist);
            //return View(db.PostsHistories.ToList());
        }

        // GET: PostsHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostsHistory postsHistory = db.PostsHistories.Find(id);
            if (postsHistory == null)
            {
                return HttpNotFound();
            }
            return View(postsHistory);
        }

        // GET: PostsHistories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostsHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HistoryId,PostID,Message,ChangedDate,UserId")] PostsHistory postsHistory)
        {
            if (ModelState.IsValid)
            {
                db.PostsHistories.Add(postsHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postsHistory);
        }

        // GET: PostsHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostsHistory postsHistory = db.PostsHistories.Find(id);
            if (postsHistory == null)
            {
                return HttpNotFound();
            }
            return View(postsHistory);
        }

        // POST: PostsHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HistoryId,PostID,Message,ChangedDate,UserId")] PostsHistory postsHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postsHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postsHistory);
        }

        // GET: PostsHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostsHistory postsHistory = db.PostsHistories.Find(id);
            if (postsHistory == null)
            {
                return HttpNotFound();
            }
            return View(postsHistory);
        }

        // POST: PostsHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostsHistory postsHistory = db.PostsHistories.Find(id);
            db.PostsHistories.Remove(postsHistory);
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
