using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comment1.Views.Posts
{
    public class PostsHistoryController : Controller
    {
        // GET: PostsHistory
        public ActionResult Index()
        {
            return View();
        }

        // GET: PostsHistory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostsHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostsHistory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsHistory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostsHistory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsHistory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostsHistory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
