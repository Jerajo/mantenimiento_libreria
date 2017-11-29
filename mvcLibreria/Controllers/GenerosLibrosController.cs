using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcLibreria;

namespace mvcLibreria.Controllers
{
    public class GenerosLibrosController : Controller
    {
        private LibHCEntities db = new LibHCEntities();

        // GET: GenerosLibros
        public ActionResult Index()
        {
            return View(db.vwGenerosLibrosCounts.ToList());
        }

        // GET: GenerosLibros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwGenerosLibrosCount vwGenerosLibrosCount = db.vwGenerosLibrosCounts.Find(id);
            if (vwGenerosLibrosCount == null)
            {
                return HttpNotFound();
            }
            return View(vwGenerosLibrosCount);
        }

        // GET: GenerosLibros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenerosLibros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Genero,Total_Libros")] vwGenerosLibrosCount vwGenerosLibrosCount)
        {
            if (ModelState.IsValid)
            {
                db.vwGenerosLibrosCounts.Add(vwGenerosLibrosCount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vwGenerosLibrosCount);
        }

        // GET: GenerosLibros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwGenerosLibrosCount vwGenerosLibrosCount = db.vwGenerosLibrosCounts.Find(id);
            if (vwGenerosLibrosCount == null)
            {
                return HttpNotFound();
            }
            return View(vwGenerosLibrosCount);
        }

        // POST: GenerosLibros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Genero,Total_Libros")] vwGenerosLibrosCount vwGenerosLibrosCount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vwGenerosLibrosCount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vwGenerosLibrosCount);
        }

        // GET: GenerosLibros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwGenerosLibrosCount vwGenerosLibrosCount = db.vwGenerosLibrosCounts.Find(id);
            if (vwGenerosLibrosCount == null)
            {
                return HttpNotFound();
            }
            return View(vwGenerosLibrosCount);
        }

        // POST: GenerosLibros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vwGenerosLibrosCount vwGenerosLibrosCount = db.vwGenerosLibrosCounts.Find(id);
            db.vwGenerosLibrosCounts.Remove(vwGenerosLibrosCount);
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
