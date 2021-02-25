using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GHMNUNIDADDECAPACITACION.Models;

namespace GHMNUNIDADDECAPACITACION.Controllers
{
    public class UnidaddeCaptacionsController : Controller
    {
        private GHUContext db = new GHUContext();

        // GET: UnidaddeCaptacions
        public ActionResult Index()
        {
            return View(db.UnidaddeCaptacion.ToList());
        }

        // GET: UnidaddeCaptacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidaddeCaptacion unidaddeCaptacion = db.UnidaddeCaptacion.Find(id);
            if (unidaddeCaptacion == null)
            {
                return HttpNotFound();
            }
            return View(unidaddeCaptacion);
        }

        // GET: UnidaddeCaptacions/Create
        public ActionResult Create()
        {
            using (GHUContext db = new GHUContext())
            {
                ViewBag.filial = new List<SelectListItem>(db.Filiales.Select(l => new SelectListItem
                { Value = l.IdFilial.ToString(), Text = l.Descripcion }));

                ViewBag.dpto = new List<SelectListItem>(db.Departamento.Select(l => new SelectListItem
                { Value = l.IdDepartamentoss.ToString(), Text = l.Descripcion }));


                ViewBag.result = db.UnidaddeCaptacion.OrderByDescending(x => x.idUnidaddeCaptacion).Take(250).ToList();
            }
            return View();
        }

        // POST: UnidaddeCaptacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUnidaddeCaptacion,filial,departamento,puestoempleado,fechasolicitud,Areadepartamento,cursorequerido,importanciacurso,cantidadempleados,fechacreacion,estadosolicitud,usuariocreacion")] UnidaddeCaptacion unidaddeCaptacion)
        {
            if (ModelState.IsValid)
            {
                db.UnidaddeCaptacion.Add(unidaddeCaptacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidaddeCaptacion);
        }

        // GET: UnidaddeCaptacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidaddeCaptacion unidaddeCaptacion = db.UnidaddeCaptacion.Find(id);
            if (unidaddeCaptacion == null)
            {
                return HttpNotFound();
            }
            return View(unidaddeCaptacion);
        }

        // POST: UnidaddeCaptacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUnidaddeCaptacion,filial,departamento,puestoempleado,fechasolicitud,Areadepartamento,cursorequerido,importanciacurso,cantidadempleados,fechacreacion,estadosolicitud,usuariocreacion")] UnidaddeCaptacion unidaddeCaptacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidaddeCaptacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidaddeCaptacion);
        }

        // GET: UnidaddeCaptacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidaddeCaptacion unidaddeCaptacion = db.UnidaddeCaptacion.Find(id);
            if (unidaddeCaptacion == null)
            {
                return HttpNotFound();
            }
            return View(unidaddeCaptacion);
        }

        // POST: UnidaddeCaptacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnidaddeCaptacion unidaddeCaptacion = db.UnidaddeCaptacion.Find(id);
            db.UnidaddeCaptacion.Remove(unidaddeCaptacion);
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
