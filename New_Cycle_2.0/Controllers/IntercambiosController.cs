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
    public class IntercambiosController : Controller
    {
        private New_CycleEntities db = new New_CycleEntities();

        // GET: Intercambios
        public ActionResult Index()
        {
            var intercambio = db.Intercambio.Include(i => i.Empresas).Include(i => i.Producto_a_intercambiar).Include(i => i.Producto_intercambiado);
            return View(intercambio.ToList());
        }

        // GET: Intercambios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intercambio intercambio = db.Intercambio.Find(id);
            if (intercambio == null)
            {
                return HttpNotFound();
            }
            return View(intercambio);
        }

        // GET: Intercambios/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaID = new SelectList(db.Empresas, "EmpresaID", "Nombre_empresa");
            ViewBag.ProductoAInterID = new SelectList(db.Producto_a_intercambiar, "ProductoAInterID", "Nombre_del_producto_a_intercambiar");
            ViewBag.ProductoInterID = new SelectList(db.Producto_intercambiado, "ProductoInterID", "Nombre_del_producto_intercambiado");
            return View();
        }

        // POST: Intercambios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IntercambioID,EmpresaID,ProductoAInterID,ProductoInterID,Descripcion_del_intercambio")] Intercambio intercambio)
        {
            if (ModelState.IsValid)
            {
                db.Intercambio.Add(intercambio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaID = new SelectList(db.Empresas, "EmpresaID", "Nombre_empresa", intercambio.EmpresaID);
            ViewBag.ProductoAInterID = new SelectList(db.Producto_a_intercambiar, "ProductoAInterID", "Nombre_del_producto_a_intercambiar", intercambio.ProductoAInterID);
            ViewBag.ProductoInterID = new SelectList(db.Producto_intercambiado, "ProductoInterID", "Nombre_del_producto_intercambiado", intercambio.ProductoInterID);
            return View(intercambio);
        }

        // GET: Intercambios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intercambio intercambio = db.Intercambio.Find(id);
            if (intercambio == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaID = new SelectList(db.Empresas, "EmpresaID", "Nombre_empresa", intercambio.EmpresaID);
            ViewBag.ProductoAInterID = new SelectList(db.Producto_a_intercambiar, "ProductoAInterID", "Nombre_del_producto_a_intercambiar", intercambio.ProductoAInterID);
            ViewBag.ProductoInterID = new SelectList(db.Producto_intercambiado, "ProductoInterID", "Nombre_del_producto_intercambiado", intercambio.ProductoInterID);
            return View(intercambio);
        }

        // POST: Intercambios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IntercambioID,EmpresaID,ProductoAInterID,ProductoInterID,Descripcion_del_intercambio")] Intercambio intercambio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intercambio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaID = new SelectList(db.Empresas, "EmpresaID", "Nombre_empresa", intercambio.EmpresaID);
            ViewBag.ProductoAInterID = new SelectList(db.Producto_a_intercambiar, "ProductoAInterID", "Nombre_del_producto_a_intercambiar", intercambio.ProductoAInterID);
            ViewBag.ProductoInterID = new SelectList(db.Producto_intercambiado, "ProductoInterID", "Nombre_del_producto_intercambiado", intercambio.ProductoInterID);
            return View(intercambio);
        }

        // GET: Intercambios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intercambio intercambio = db.Intercambio.Find(id);
            if (intercambio == null)
            {
                return HttpNotFound();
            }
            return View(intercambio);
        }

        // POST: Intercambios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Intercambio intercambio = db.Intercambio.Find(id);
            db.Intercambio.Remove(intercambio);
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
