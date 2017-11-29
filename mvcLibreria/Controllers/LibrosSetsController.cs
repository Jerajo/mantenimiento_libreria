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
    public class LibrosSetsController : Controller
    {
        private LibHCEntities db = new LibHCEntities();

        // GET: LibrosSets
        public ActionResult Index()
        {
            var librosSets = db.LibrosSets.Include(l => l.CategoriasSet);
            return View(librosSets.ToList());
        }

        // GET: LibrosSets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibrosSet librosSet = db.LibrosSets.Find(id);
            if (librosSet == null)
            {
                return HttpNotFound();
            }
            return View(librosSet);
        }

        // GET: LibrosSets/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.CategoriasSets, "Id", "Genero");
            return View();
        }

        // POST: LibrosSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ISBN,Titulo,Pais,Stock,Editorial,CategoriaId")] LibrosSet librosSet)
        {
            if (ModelState.IsValid)
            {
                db.LibrosSets.Add(librosSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.CategoriasSets, "Id", "Genero", librosSet.CategoriaId);
            return View(librosSet);
        }

        // GET: LibrosSets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibrosSet librosSet = db.LibrosSets.Find(id);
            if (librosSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.CategoriasSets, "Id", "Genero", librosSet.CategoriaId);
            return View(librosSet);
        }

        // POST: LibrosSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ISBN,Titulo,Pais,Stock,Editorial,CategoriaId")] LibrosSet librosSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(librosSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.CategoriasSets, "Id", "Genero", librosSet.CategoriaId);
            return View(librosSet);
        }

        // GET: LibrosSets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibrosSet librosSet = db.LibrosSets.Find(id);
            if (librosSet == null)
            {
                return HttpNotFound();
            }
            return View(librosSet);
        }

        // POST: LibrosSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LibrosSet librosSet = db.LibrosSets.Find(id);
            db.LibrosSets.Remove(librosSet);
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
