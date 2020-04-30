using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppBiblioteca.Models;

namespace WebAppBiblioteca.Controllers
{
    public class EstanteriasController : Controller
    {
        private BD_BIBLIOTECAEntities db = new BD_BIBLIOTECAEntities();

        // GET: Estanterias
        public ActionResult Index()
        {
            return View(db.Estanteria.ToList());
        }

        // GET: Estanterias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estanteria estanteria = db.Estanteria.Find(id);
            if (estanteria == null)
            {
                return HttpNotFound();
            }
            return View(estanteria);
        }

        // GET: Estanterias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estanterias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoEstanteria,capacidad")] Estanteria estanteria)
        {
            if (ModelState.IsValid)
            {
                db.Estanteria.Add(estanteria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estanteria);
        }

        // GET: Estanterias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estanteria estanteria = db.Estanteria.Find(id);
            if (estanteria == null)
            {
                return HttpNotFound();
            }
            return View(estanteria);
        }

        // POST: Estanterias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoEstanteria,capacidad")] Estanteria estanteria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estanteria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estanteria);
        }

        // GET: Estanterias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estanteria estanteria = db.Estanteria.Find(id);
            if (estanteria == null)
            {
                return HttpNotFound();
            }
            return View(estanteria);
        }

        // POST: Estanterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Estanteria estanteria = db.Estanteria.Find(id);
            db.Estanteria.Remove(estanteria);
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
