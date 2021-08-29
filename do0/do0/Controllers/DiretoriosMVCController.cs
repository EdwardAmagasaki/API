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
    public class DiretoriosMVCController : Controller
    {
        private FormasContext db = new FormasContext();

        // GET: DiretoriosMVC
        public ActionResult Index()
        {
            return View(db.Diretorios.ToList());
        }

        // GET: DiretoriosMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diretorio diretorio = db.Diretorios.Find(id);
            if (diretorio == null)
            {
                return HttpNotFound();
            }
            return View(diretorio);
        }

        // GET: DiretoriosMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiretoriosMVC/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiretorioId,NomeDiretorio")] Diretorio diretorio)
        {
            if (ModelState.IsValid)
            {
                db.Diretorios.Add(diretorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diretorio);
        }

        // GET: DiretoriosMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diretorio diretorio = db.Diretorios.Find(id);
            if (diretorio == null)
            {
                return HttpNotFound();
            }
            return View(diretorio);
        }

        // POST: DiretoriosMVC/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiretorioId,NomeDiretorio")] Diretorio diretorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diretorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diretorio);
        }

        // GET: DiretoriosMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diretorio diretorio = db.Diretorios.Find(id);
            if (diretorio == null)
            {
                return HttpNotFound();
            }
            return View(diretorio);
        }

        // POST: DiretoriosMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diretorio diretorio = db.Diretorios.Find(id);
            db.Diretorios.Remove(diretorio);
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
