using System;
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
    public class AlumnoCursoesController : Controller
    {
        private AlumnosContext db = new AlumnosContext();

        // GET: AlumnoCursoes
        public ActionResult Index()
        {
            var alumnoCursoes = db.AlumnoCursoes.Include(a => a.IdAlumnoNavigation).Include(a => a.IdCursoNavigation);
            return View(alumnoCursoes.ToList());
        }

        // GET: AlumnoCursoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoCurso alumnoCurso = db.AlumnoCursoes.Find(id);
            if (alumnoCurso == null)
            {
                return HttpNotFound();
            }
            return View(alumnoCurso);
        }

        // GET: AlumnoCursoes/Create
        public ActionResult Create()
        {
            ViewBag.IdAlumno = new SelectList(db.Alumnos, "IdAlumno", "Nombre");
            ViewBag.IdCurso = new SelectList(db.Cursos, "IdCurso", "Nombre");
            return View();
        }

        // POST: AlumnoCursoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdAlumno,IdCurso")] AlumnoCurso alumnoCurso)
        {
            if (ModelState.IsValid)
            {
                db.AlumnoCursoes.Add(alumnoCurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAlumno = new SelectList(db.Alumnos, "IdAlumno", "Nombre", alumnoCurso.IdAlumno);
            ViewBag.IdCurso = new SelectList(db.Cursos, "IdCurso", "Nombre", alumnoCurso.IdCurso);
            return View(alumnoCurso);
        }

        // GET: AlumnoCursoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoCurso alumnoCurso = db.AlumnoCursoes.Find(id);
            if (alumnoCurso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAlumno = new SelectList(db.Alumnos, "IdAlumno", "Nombre", alumnoCurso.IdAlumno);
            ViewBag.IdCurso = new SelectList(db.Cursos, "IdCurso", "Nombre", alumnoCurso.IdCurso);
            return View(alumnoCurso);
        }

        // POST: AlumnoCursoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdAlumno,IdCurso")] AlumnoCurso alumnoCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnoCurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAlumno = new SelectList(db.Alumnos, "IdAlumno", "Nombre", alumnoCurso.IdAlumno);
            ViewBag.IdCurso = new SelectList(db.Cursos, "IdCurso", "Nombre", alumnoCurso.IdCurso);
            return View(alumnoCurso);
        }

        // GET: AlumnoCursoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoCurso alumnoCurso = db.AlumnoCursoes.Find(id);
            if (alumnoCurso == null)
            {
                return HttpNotFound();
            }
            return View(alumnoCurso);
        }

        // POST: AlumnoCursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlumnoCurso alumnoCurso = db.AlumnoCursoes.Find(id);
            db.AlumnoCursoes.Remove(alumnoCurso);
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
