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
    public class CredencialesSetsController : Controller
    {
        private LibHCEntities db = new LibHCEntities();

        // GET: CredencialesSets
        public ActionResult Index()
        {
            return View(db.CredencialesSets.ToList());
        }

        // GET: CredencialesSets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CredencialesSet credencialesSet = db.CredencialesSets.Find(id);
            if (credencialesSet == null)
            {
                return HttpNotFound();
            }
            return View(credencialesSet);
        }

        // GET: CredencialesSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CredencialesSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nombre,Password")] CredencialesSet credencialesSet)
        {
            if (ModelState.IsValid)
            {
                db.CredencialesSets.Add(credencialesSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(credencialesSet);
        }

        // GET: CredencialesSets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CredencialesSet credencialesSet = db.CredencialesSets.Find(id);
            if (credencialesSet == null)
            {
                return HttpNotFound();
            }
            return View(credencialesSet);
        }

        // POST: CredencialesSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nombre,Password")] CredencialesSet credencialesSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(credencialesSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(credencialesSet);
        }

        // GET: CredencialesSets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CredencialesSet credencialesSet = db.CredencialesSets.Find(id);
            if (credencialesSet == null)
            {
                return HttpNotFound();
            }
            return View(credencialesSet);
        }

        // POST: CredencialesSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CredencialesSet credencialesSet = db.CredencialesSets.Find(id);
            db.CredencialesSets.Remove(credencialesSet);
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
