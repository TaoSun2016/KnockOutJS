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
    public class MTB_ArticlesController : Controller
    {
        private KODBEntities db = new KODBEntities();

        // GET: MTB_Articles
        public ActionResult Index()
        {
            return View(db.MTB_Articles.ToList());
        }

        // GET: MTB_Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MTB_Articles mTB_Articles = db.MTB_Articles.Find(id);
            if (mTB_Articles == null)
            {
                return HttpNotFound();
            }
            return View(mTB_Articles);
        }

        // GET: MTB_Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MTB_Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Excerpts,Content")] MTB_Articles mTB_Articles)
        {
            if (ModelState.IsValid)
            {
                db.MTB_Articles.Add(mTB_Articles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mTB_Articles);
        }

        // GET: MTB_Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MTB_Articles mTB_Articles = db.MTB_Articles.Find(id);
            if (mTB_Articles == null)
            {
                return HttpNotFound();
            }
            return View(mTB_Articles);
        }

        // POST: MTB_Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Excerpts,Content")] MTB_Articles mTB_Articles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mTB_Articles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mTB_Articles);
        }

        // GET: MTB_Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MTB_Articles mTB_Articles = db.MTB_Articles.Find(id);
            if (mTB_Articles == null)
            {
                return HttpNotFound();
            }
            return View(mTB_Articles);
        }

        // POST: MTB_Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MTB_Articles mTB_Articles = db.MTB_Articles.Find(id);
            db.MTB_Articles.Remove(mTB_Articles);
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
