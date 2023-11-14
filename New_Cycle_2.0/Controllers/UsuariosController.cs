using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using New_Cycle_2._0;

namespace New_Cycle_2._0.Controllers
{
    public class UsuariosController : Controller
    {
        private New_CycleEntities db = new New_CycleEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioID,Nombre,Email,Telefono,Contraseña,ConfirmarContraseña,Tipo_de_Usuario")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                // Convierte el tipo de usuario a minúsculas y capitaliza la primera letra
                usuarios.Tipo_de_Usuario = usuarios.Tipo_de_Usuario.ToLower();
                usuarios.Tipo_de_Usuario = char.ToUpper(usuarios.Tipo_de_Usuario[0]) + usuarios.Tipo_de_Usuario.Substring(1);

                if (ModelState.IsValid)
                {
                    // Verificar si las contraseñas coinciden
                    if (usuarios.Contraseña == usuarios.ConfirmarContraseña)
                    {
                        // Verifica si el tipo de usuario es válido
                        if (usuarios.Tipo_de_Usuario == "Empresa" || usuarios.Tipo_de_Usuario == "Cliente" || usuarios.Tipo_de_Usuario == "Colaborador")
                        {
                            // Crear un nuevo registro de usuario en la tabla de Usuarios
                            db.Usuarios.Add(usuarios);
                            db.SaveChanges();

                            // Según el tipo de usuario seleccionado (entrada del usuario), crear un registro en la tabla correspondiente
                            if (usuarios.Tipo_de_Usuario == "Empresa")
                            {
                                var empresa = new Empresas { UsuarioID = usuarios.UsuarioID, Nombre_empresa = usuarios.Nombre, Email = usuarios.Email, Telefono = usuarios.Telefono, Contraseña = usuarios.Contraseña };
                                db.Empresas.Add(empresa);
                            }
                            else if (usuarios.Tipo_de_Usuario == "Cliente")
                            {
                                var cliente = new Clientes { UsuarioID = usuarios.UsuarioID, Nombre_Cliente = usuarios.Nombre, Email = usuarios.Email, Telefono = usuarios.Telefono, Contraseña = usuarios.Contraseña };
                                db.Clientes.Add(cliente);
                            }
                            else if (usuarios.Tipo_de_Usuario == "Colaborador")
                            {
                                var colaborador = new Colaboradores { UsuarioID = usuarios.UsuarioID, Nombre_Colaborador = usuarios.Nombre, Email = usuarios.Email, Telefono = usuarios.Telefono, Contraseña = usuarios.Contraseña };
                                db.Colaboradores.Add(colaborador);
                            }

                            db.SaveChanges();
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            // Tipo de usuario no válido, muestra un mensaje de error
                            ModelState.AddModelError("Tipo_de_Usuario", "El tipo de usuario no es válido.");
                        }
                    }
                    else
                    {
                        // Las contraseñas no coinciden, muestra un mensaje de error
                        ModelState.AddModelError("ConfirmarContraseña", "Las contraseñas no coinciden.");
                    }
                }
            }

            return View(usuarios);
        }



        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioID,Nombre,Email,Telefono,Contraseña,ConfirmarContraseña,Tipo_de_Usuario")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                if (usuarios.Contraseña == usuarios.ConfirmarContraseña)
                {
                    db.Entry(usuarios).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    // Las contraseñas no coinciden, muestra un mensaje de error
                    ModelState.AddModelError("ConfirmarContraseña", "Las contraseñas no coinciden.");
                }

            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios usuarios)
        {
            var lst = from d in db.Usuarios where d.Email == usuarios.Email && d.Contraseña == usuarios.Contraseña && d.Tipo_de_Usuario == usuarios.Tipo_de_Usuario select d;
            if (usuarios.Tipo_de_Usuario != null)
            {
                usuarios.Tipo_de_Usuario = usuarios.Tipo_de_Usuario.ToLower();
                usuarios.Tipo_de_Usuario = char.ToUpper(usuarios.Tipo_de_Usuario[0]) + usuarios.Tipo_de_Usuario.Substring(1);
            }
            if (lst.Count() > 0)
            {
                if (usuarios.Tipo_de_Usuario == "Colaborador")
                {
                    // Redirigir al controlador y acción correspondiente para empresas
                    return RedirectToAction("tipoColaborador", "Home"); 
                }
                else if (usuarios.Tipo_de_Usuario == "Cliente" || usuarios.Tipo_de_Usuario == "Empresa")
                {
                    // Redirigir al controlador y acción correspondiente para clientes o colaboradores
                    return RedirectToAction("Index", "Home");
                }
                
            }
            else
            {
                ModelState.AddModelError("", "Las credenciales son incorrectas.");
            }

            return View(usuarios);
    
        }


        public ActionResult ConfirmarCorreo()
        {
            return View();
        }

        

        public ActionResult Comerzalizacion()
        {
            return View();
        }

        public ActionResult LoginFigma()
        {
            return View();
        }

        

    }


}

