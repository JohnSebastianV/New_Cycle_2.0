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
    public class Producto_a_intercambiarController : Controller
    {
        private New_CycleEntities db = new New_CycleEntities();

        // GET: Producto_a_intercambiar
        public ActionResult Index()
        {
            return View(db.Producto_a_intercambiar.ToList());
        }

        // GET: Producto_a_intercambiar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto_a_intercambiar producto_a_intercambiar = db.Producto_a_intercambiar.Find(id);
            if (producto_a_intercambiar == null)
            {
                return HttpNotFound();
            }
            return View(producto_a_intercambiar);
        }

        // GET: Producto_a_intercambiar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto_a_intercambiar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoAInterID,Nombre_del_producto_a_intercambiar")] Producto_a_intercambiar producto_a_intercambiar)
        {
            if (ModelState.IsValid)
            {
                db.Producto_a_intercambiar.Add(producto_a_intercambiar);
                db.SaveChanges();
                return RedirectToAction("Index", "Intercambios");
            }

            return View(producto_a_intercambiar);
        }

        // GET: Producto_a_intercambiar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto_a_intercambiar producto_a_intercambiar = db.Producto_a_intercambiar.Find(id);
            if (producto_a_intercambiar == null)
            {
                return HttpNotFound();
            }
            return View(producto_a_intercambiar);
        }

        // POST: Producto_a_intercambiar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoAInterID,Nombre_del_producto_a_intercambiar")] Producto_a_intercambiar producto_a_intercambiar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto_a_intercambiar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto_a_intercambiar);
        }

        // GET: Producto_a_intercambiar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto_a_intercambiar producto_a_intercambiar = db.Producto_a_intercambiar.Find(id);
            if (producto_a_intercambiar == null)
            {
                return HttpNotFound();
            }
            return View(producto_a_intercambiar);
        }

        // POST: Producto_a_intercambiar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto_a_intercambiar producto_a_intercambiar = db.Producto_a_intercambiar.Find(id);
            db.Producto_a_intercambiar.Remove(producto_a_intercambiar);
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
