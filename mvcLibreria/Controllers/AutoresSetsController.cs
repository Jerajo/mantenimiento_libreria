using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace mvcLibreria
{
    public class AutoresSetsController : Controller
    {
        private LibHCEntities db = new LibHCEntities();

        // GET: AutoresSets
        public ActionResult Index()
        {
            return View(db.AutoresSets.ToList());
        }

        // GET: AutoresSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoresSet autoresSet = db.AutoresSets.Find(id);
            if (autoresSet == null)
            {
                return HttpNotFound();
            }
            return View(autoresSet);
        }

        // GET: AutoresSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutoresSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido")] AutoresSet autoresSet)
        {
            if (ModelState.IsValid)
            {
                db.AutoresSets.Add(autoresSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autoresSet);
        }

        // GET: AutoresSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoresSet autoresSet = db.AutoresSets.Find(id);
            if (autoresSet == null)
            {
                return HttpNotFound();
            }
            return View(autoresSet);
        }

        // POST: AutoresSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido")] AutoresSet autoresSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoresSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autoresSet);
        }

        // GET: AutoresSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoresSet autoresSet = db.AutoresSets.Find(id);
            if (autoresSet == null)
            {
                return HttpNotFound();
            }
            return View(autoresSet);
        }

        // POST: AutoresSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoresSet autoresSet = db.AutoresSets.Find(id);
            db.AutoresSets.Remove(autoresSet);
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
