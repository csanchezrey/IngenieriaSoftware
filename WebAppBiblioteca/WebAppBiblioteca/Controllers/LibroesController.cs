﻿using System;
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
    public class LibroesController : Controller
    {
        private BD_BIBLIOTECAEntities db = new BD_BIBLIOTECAEntities();

        // GET: Libroes
        public ActionResult Index()
        {
            var libro = db.Libro.Include(l => l.Estanteria).Include(l => l.Tematica);
            return View(libro.ToList());
        }

        // GET: Libroes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libroes/Create
        public ActionResult Create()
        {
            ViewBag.codigoEstanteria = new SelectList(db.Estanteria, "codigoEstanteria", "codigoEstanteria");
            ViewBag.codigoTematica = new SelectList(db.Tematica, "codigo", "descripcion");
            return View();
        }

        // POST: Libroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoISBN,titulo,codigoTematica,codigoEstanteria")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Libro.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoEstanteria = new SelectList(db.Estanteria, "codigoEstanteria", "codigoEstanteria", libro.codigoEstanteria);
            ViewBag.codigoTematica = new SelectList(db.Tematica, "codigo", "descripcion", libro.codigoTematica);
            return View(libro);
        }

        // GET: Libroes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoEstanteria = new SelectList(db.Estanteria, "codigoEstanteria", "codigoEstanteria", libro.codigoEstanteria);
            ViewBag.codigoTematica = new SelectList(db.Tematica, "codigo", "descripcion", libro.codigoTematica);
            return View(libro);
        }

        // POST: Libroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoISBN,titulo,codigoTematica,codigoEstanteria")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoEstanteria = new SelectList(db.Estanteria, "codigoEstanteria", "codigoEstanteria", libro.codigoEstanteria);
            ViewBag.codigoTematica = new SelectList(db.Tematica, "codigo", "descripcion", libro.codigoTematica);
            return View(libro);
        }

        // GET: Libroes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Libro libro = db.Libro.Find(id);
            db.Libro.Remove(libro);
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
