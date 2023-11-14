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
    public class Formu_calidadController : Controller
    {
        private New_cycle_Com_RecoEntities db = new New_cycle_Com_RecoEntities();

        // GET: Formu_calidad
        public ActionResult Index()
        {
            var formu_calidad = db.Formu_calidad.Include(f => f.Ruta);
            return View(formu_calidad.ToList());
        }

        // GET: Formu_calidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formu_calidad formu_calidad = db.Formu_calidad.Find(id);
            if (formu_calidad == null)
            {
                return HttpNotFound();
            }
            return View(formu_calidad);
        }

        // GET: Formu_calidad/Create
        public ActionResult Create()
        {
            ViewBag.RutaID = new SelectList(db.Ruta, "RutaID", "Ruta1");
            return View();
        }

        // POST: Formu_calidad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormularioID,Observaciones,Aspectos_a_mejorar,RutaID")] Formu_calidad formu_calidad)
        {
            if (ModelState.IsValid)
            {
                db.Formu_calidad.Add(formu_calidad);
                db.SaveChanges();
                return RedirectToAction("Index", "PuntoEntregas");
            }

            ViewBag.RutaID = new SelectList(db.Ruta, "RutaID", "Ruta1", formu_calidad.RutaID);
            return View(formu_calidad);
        }

        // GET: Formu_calidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formu_calidad formu_calidad = db.Formu_calidad.Find(id);
            if (formu_calidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.RutaID = new SelectList(db.Ruta, "RutaID", "Ruta1", formu_calidad.RutaID);
            return View(formu_calidad);
        }

        // POST: Formu_calidad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormularioID,Observaciones,Aspectos_a_mejorar,RutaID")] Formu_calidad formu_calidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formu_calidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RutaID = new SelectList(db.Ruta, "RutaID", "Ruta1", formu_calidad.RutaID);
            return View(formu_calidad);
        }

        // GET: Formu_calidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formu_calidad formu_calidad = db.Formu_calidad.Find(id);
            if (formu_calidad == null)
            {
                return HttpNotFound();
            }
            return View(formu_calidad);
        }

        // POST: Formu_calidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formu_calidad formu_calidad = db.Formu_calidad.Find(id);
            db.Formu_calidad.Remove(formu_calidad);
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
