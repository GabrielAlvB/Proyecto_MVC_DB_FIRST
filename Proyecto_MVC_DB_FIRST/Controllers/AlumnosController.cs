﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_MVC_DB_FIRST.Data;
using Proyecto_MVC_DB_FIRST.Models;

namespace Proyecto_MVC_DB_FIRST.Controllers
{
    public class AlumnosController : Controller
    {
        private AlumnosContext db = new AlumnosContext();

        // GET: Alumnos
        public ActionResult Index()
        {
            return View(db.Alumnos.ToList());
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos alumnos = db.Alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAlumno,Nombre,Edad,Grado")] Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Alumnos.Add(alumnos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alumnos);
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos alumnos = db.Alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // POST: Alumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAlumno,Nombre,Edad,Grado")] Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumnos);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos alumnos = db.Alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumnos alumnos = db.Alumnos.Find(id);
            db.Alumnos.Remove(alumnos);
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
