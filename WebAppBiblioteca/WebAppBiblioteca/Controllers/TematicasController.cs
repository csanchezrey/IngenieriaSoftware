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
    public class TematicasController : Controller
    {
        private BD_BIBLIOTECAEntities db = new BD_BIBLIOTECAEntities();

        // GET: Tematicas
        public ActionResult Index()
        {
            return View(db.Tematica.ToList());
        }

        // GET: Tematicas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tematica tematica = db.Tematica.Find(id);
            if (tematica == null)
            {
                return HttpNotFound();
            }
            return View(tematica);
        }

        // GET: Tematicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tematicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,descripcion")] Tematica tematica)
        {
            if (ModelState.IsValid)
            {
                db.Tematica.Add(tematica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tematica);
        }

        // GET: Tematicas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tematica tematica = db.Tematica.Find(id);
            if (tematica == null)
            {
                return HttpNotFound();
            }
            return View(tematica);
        }

        // POST: Tematicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,descripcion")] Tematica tematica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tematica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tematica);
        }

        // GET: Tematicas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tematica tematica = db.Tematica.Find(id);
            if (tematica == null)
            {
                return HttpNotFound();
            }
            return View(tematica);
        }

        // POST: Tematicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tematica tematica = db.Tematica.Find(id);
            db.Tematica.Remove(tematica);
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
