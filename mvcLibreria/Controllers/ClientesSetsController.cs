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
    public class ClientesSetsController : Controller
    {
        private LibHCEntities db = new LibHCEntities();

        // GET: ClientesSets
        public ActionResult Index()
        {
            return View(db.ClientesSets.ToList());
        }

        // GET: ClientesSets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesSet clientesSet = db.ClientesSets.Find(id);
            if (clientesSet == null)
            {
                return HttpNotFound();
            }
            return View(clientesSet);
        }

        // GET: ClientesSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identificacion,Nombre,Apellido,Telefono,Correo")] ClientesSet clientesSet)
        {
            if (ModelState.IsValid)
            {
                db.ClientesSets.Add(clientesSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientesSet);
        }

        // GET: ClientesSets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesSet clientesSet = db.ClientesSets.Find(id);
            if (clientesSet == null)
            {
                return HttpNotFound();
            }
            return View(clientesSet);
        }

        // POST: ClientesSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identificacion,Nombre,Apellido,Telefono,Correo")] ClientesSet clientesSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientesSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientesSet);
        }

        // GET: ClientesSets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesSet clientesSet = db.ClientesSets.Find(id);
            if (clientesSet == null)
            {
                return HttpNotFound();
            }
            return View(clientesSet);
        }

        // POST: ClientesSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ClientesSet clientesSet = db.ClientesSets.Find(id);
            db.ClientesSets.Remove(clientesSet);
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
