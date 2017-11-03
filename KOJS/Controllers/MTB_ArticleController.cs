using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KOJS.Models;

namespace KOJS.Controllers
{
    public class MTB_ArticleController : Controller
    {
        private KOJSContext db = new KOJSContext();

        // GET: MTB_Article
        public ActionResult Index()
        {
            return View(db.MTB_Article.ToList());
        }

        // GET: MTB_Article/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MTB_Article mTB_Article = db.MTB_Article.Find(id);
            if (mTB_Article == null)
            {
                return HttpNotFound();
            }
            return View(mTB_Article);
        }

        // GET: MTB_Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MTB_Article/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Title,Excerpts,Content")] MTB_Article mTB_Article)
        {
            if (ModelState.IsValid)
            {
                db.MTB_Article.Add(mTB_Article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mTB_Article);
        }

        // GET: MTB_Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MTB_Article mTB_Article = db.MTB_Article.Find(id);
            if (mTB_Article == null)
            {
                return HttpNotFound();
            }
            return View(mTB_Article);
        }

        // POST: MTB_Article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Title,Excerpts,Content")] MTB_Article mTB_Article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mTB_Article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mTB_Article);
        }

        // GET: MTB_Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MTB_Article mTB_Article = db.MTB_Article.Find(id);
            if (mTB_Article == null)
            {
                return HttpNotFound();
            }
            return View(mTB_Article);
        }

        // POST: MTB_Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MTB_Article mTB_Article = db.MTB_Article.Find(id);
            db.MTB_Article.Remove(mTB_Article);
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
