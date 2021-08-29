using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using do0.Models;

namespace do0.Controllers
{
    public class FormasMVCController : Controller
    {
        private FormasContext db = new FormasContext();

        // GET: FormasMVC
        public ActionResult Index()
        {
            var formas = db.Formas.Include(f => f.DiretorioItem);
            return View(formas.ToList());
        }

        // GET: FormasMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formas formas = db.Formas.Find(id);
            if (formas == null)
            {
                return HttpNotFound();
            }
            return View(formas);
        }

        // GET: FormasMVC/Create
        public ActionResult Create()
        {
            ViewBag.DiretorioId = new SelectList(db.Diretorios, "DiretorioId", "NomeDiretorio");
            return View();
        }

        // POST: FormasMVC/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormasId,NomeForma,TipoForma,Cor,TamanhoPixels,DiretorioId")] Formas formas)
        {
            if (ModelState.IsValid)
            {
                db.Formas.Add(formas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiretorioId = new SelectList(db.Diretorios, "DiretorioId", "NomeDiretorio", formas.DiretorioId);
            return View(formas);
        }

        // GET: FormasMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formas formas = db.Formas.Find(id);
            if (formas == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiretorioId = new SelectList(db.Diretorios, "DiretorioId", "NomeDiretorio", formas.DiretorioId);
            return View(formas);
        }

        // POST: FormasMVC/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormasId,NomeForma,TipoForma,Cor,TamanhoPixels,DiretorioId")] Formas formas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiretorioId = new SelectList(db.Diretorios, "DiretorioId", "NomeDiretorio", formas.DiretorioId);
            return View(formas);
        }

        // GET: FormasMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formas formas = db.Formas.Find(id);
            if (formas == null)
            {
                return HttpNotFound();
            }
            return View(formas);
        }

        // POST: FormasMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formas formas = db.Formas.Find(id);
            db.Formas.Remove(formas);
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
