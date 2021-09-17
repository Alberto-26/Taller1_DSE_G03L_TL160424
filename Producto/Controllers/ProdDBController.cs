using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Producto.Models;

namespace Producto.Controllers
{
    public class ProdDBController : Controller
    {
        private ProductoDBContext db = new ProductoDBContext();

        // GET: ProdDB
        public ActionResult Index(string BuscarProd)
        {
            var Bprod = from p in db.Producto select p;

            if (!String.IsNullOrEmpty(BuscarProd))
            {
                Bprod = Bprod.Where(bp => bp.Descripcion.Contains(BuscarProd));
            }

            return View(Bprod);
        }

        // GET: ProdDB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Producto.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: ProdDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdDB/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Categoria,Costo,PrecioVenta,Existencia,NumPedidos")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productos);
        }

        // GET: ProdDB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Producto.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: ProdDB/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Categoria,Costo,PrecioVenta,Existencia,NumPedidos")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productos);
        }

        // GET: ProdDB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Producto.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: ProdDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Producto.Find(id);
            db.Producto.Remove(productos);
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
