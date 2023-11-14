using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using New_Cycle_2._0;

namespace New_Cycle_2._0.Controllers
{
    public class PuntoEntregasController : Controller
    {
        private New_cycle_Com_RecoEntities db = new New_cycle_Com_RecoEntities();

        // GET: PuntoEntregas
        public ActionResult Index()
        {
            return View(db.PuntoEntrega.ToList());
        }

        // GET: PuntoEntregas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuntoEntrega puntoEntrega = db.PuntoEntrega.Find(id);
            if (puntoEntrega == null)
            {
                return HttpNotFound();
            }
            return View(puntoEntrega);
        }

        // GET: PuntoEntregas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PuntoEntregas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PuntoEntregaID,Nombre_del_punto,Direccion,Tipo_de_residuos")] PuntoEntrega puntoEntrega)
        {
            if (ModelState.IsValid)
            {
                db.PuntoEntrega.Add(puntoEntrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(puntoEntrega);
        }

        // GET: PuntoEntregas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuntoEntrega puntoEntrega = db.PuntoEntrega.Find(id);
            if (puntoEntrega == null)
            {
                return HttpNotFound();
            }
            return View(puntoEntrega);
        }

        // POST: PuntoEntregas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PuntoEntregaID,Nombre_del_punto,Direccion,Tipo_de_residuos")] PuntoEntrega puntoEntrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puntoEntrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(puntoEntrega);
        }

        // GET: PuntoEntregas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuntoEntrega puntoEntrega = db.PuntoEntrega.Find(id);
            if (puntoEntrega == null)
            {
                return HttpNotFound();
            }
            return View(puntoEntrega);
        }

        // POST: PuntoEntregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PuntoEntrega puntoEntrega = db.PuntoEntrega.Find(id);
            db.PuntoEntrega.Remove(puntoEntrega);
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
