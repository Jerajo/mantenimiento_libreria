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
    public class CategoriasSetsController : Controller
    {
        private LibHCEntities db = new LibHCEntities();

        // GET: CategoriasSets
        public ActionResult Index()
        {
            return View(db.CategoriasSets.ToList());
        }

        // GET: CategoriasSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriasSet categoriasSet = db.CategoriasSets.Find(id);
            if (categoriasSet == null)
            {
                return HttpNotFound();
            }
            return View(categoriasSet);
        }

        // GET: CategoriasSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Genero")] CategoriasSet categoriasSet)
        {
            if (ModelState.IsValid)
            {
                db.CategoriasSets.Add(categoriasSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriasSet);
        }

        // GET: CategoriasSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriasSet categoriasSet = db.CategoriasSets.Find(id);
            if (categoriasSet == null)
            {
                return HttpNotFound();
            }
            return View(categoriasSet);
        }

        // POST: CategoriasSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Genero")] CategoriasSet categoriasSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriasSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriasSet);
        }

        // GET: CategoriasSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriasSet categoriasSet = db.CategoriasSets.Find(id);
            if (categoriasSet == null)
            {
                return HttpNotFound();
            }
            return View(categoriasSet);
        }

        // POST: CategoriasSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriasSet categoriasSet = db.CategoriasSets.Find(id);
            db.CategoriasSets.Remove(categoriasSet);
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
