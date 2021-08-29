using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using do0.Models;

namespace do0.Controllers
{
    public class DiretoriosController : ApiController
    {
        private FormasContext db = new FormasContext();

        // GET: api/Diretorios
        public List<Diretorio> GetDiretorios()
        {
            var a = db.Diretorios.ToList();
            return a;
        }

        // GET: api/Diretorios/5
        [ResponseType(typeof(Diretorio))]
        public IHttpActionResult GetDiretorio(int id)
        {
            Diretorio diretorio = db.Diretorios.Find(id);
            if (diretorio == null)
            {
                return NotFound();
            }

            return Ok(diretorio);
        }

        // PUT: api/Diretorios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiretorio(int id, Diretorio diretorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diretorio.DiretorioId)
            {
                return BadRequest();
            }

            db.Entry(diretorio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiretorioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Diretorios
        [ResponseType(typeof(Diretorio))]
        public IHttpActionResult PostDiretorio(Diretorio diretorio)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json("ERRO");
            }

            db.Diretorios.Add(diretorio);
            db.SaveChanges();

            return Json("OK");
            //return CreatedAtRoute("DefaultApi", new { id = diretorio.DiretorioId }, diretorio);
        }

        // DELETE: api/Diretorios/5
        [ResponseType(typeof(Diretorio))]
        public IHttpActionResult DeleteDiretorio(int id)
        {
            Diretorio diretorio = db.Diretorios.Find(id);
            if (diretorio == null)
            {
                return NotFound();
            }

            db.Diretorios.Remove(diretorio);
            db.SaveChanges();

            return Ok(diretorio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiretorioExists(int id)
        {
            return db.Diretorios.Count(e => e.DiretorioId == id) > 0;
        }
    }
}