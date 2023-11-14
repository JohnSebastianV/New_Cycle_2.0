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
    public class Producto_intercambiadoController : Controller
    {
        private New_CycleEntities db = new New_CycleEntities();

        // GET: Producto_intercambiado
        public ActionResult Index()
        {
            return View(db.Producto_intercambiado.ToList());
        }

        // GET: Producto_intercambiado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto_intercambiado producto_intercambiado = db.Producto_intercambiado.Find(id);
            if (producto_intercambiado == null)
            {
                return HttpNotFound();
            }
            return View(producto_intercambiado);
        }

        // GET: Producto_intercambiado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto_intercambiado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoInterID,Nombre_del_producto_intercambiado")] Producto_intercambiado producto_intercambiado)
        {
            if (ModelState.IsValid)
            {
                db.Producto_intercambiado.Add(producto_intercambiado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto_intercambiado);
        }

        // GET: Producto_intercambiado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto_intercambiado producto_intercambiado = db.Producto_intercambiado.Find(id);
            if (producto_intercambiado == null)
            {
                return HttpNotFound();
            }
            return View(producto_intercambiado);
        }

        // POST: Producto_intercambiado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoInterID,Nombre_del_producto_intercambiado")] Producto_intercambiado producto_intercambiado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto_intercambiado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto_intercambiado);
        }

        // GET: Producto_intercambiado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto_intercambiado producto_intercambiado = db.Producto_intercambiado.Find(id);
            if (producto_intercambiado == null)
            {
                return HttpNotFound();
            }
            return View(producto_intercambiado);
        }

        // POST: Producto_intercambiado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto_intercambiado producto_intercambiado = db.Producto_intercambiado.Find(id);
            db.Producto_intercambiado.Remove(producto_intercambiado);
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
