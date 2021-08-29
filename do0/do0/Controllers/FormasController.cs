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
    public class FormasController : ApiController
    {
        private FormasContext db = new FormasContext();

        // GET: api/Formas
        public List<Formas> GetFormas()
        {
            var a = db.Formas.ToList();
            return a;
        }


        [Route("api/formas/GetTipo")]
        [HttpGet]
        public List<FormasTipo> GetTipo()
        {

            var a = (from p in db.Formas select p.TipoForma).ToList();

            var enumerationType = typeof(Tipo);

             if (!enumerationType.IsEnum)
                 throw new ArgumentException("Enumeration type is expected.");

             //var dictionary = new Dictionary<int, string>();
             List<FormasTipo> Tipos = new List<FormasTipo>();

             foreach (int value in Enum.GetValues(enumerationType))
             {
                 var name = Enum.GetName(enumerationType, value);
               //  dictionary.Add(value, name);
                 Tipos.Add( new FormasTipo { TipoId = value, NomeTipo = name });
             }
             
            return Tipos;
        }

        // GET: api/Formas/5
        [ResponseType(typeof(Formas))]
        public IHttpActionResult GetFormas(int id)
        {
            Formas formas = db.Formas.Find(id);
            if (formas == null)
            {
                return NotFound();
            }

            return Ok(formas);
        }

        // PUT: api/Formas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFormas(int id, Formas formas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formas.FormasId)
            {
                return BadRequest();
            }

            db.Entry(formas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormasExists(id))
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

        // POST: api/Formas
        [ResponseType(typeof(Formas))]
        public IHttpActionResult PostFormas(Formas formas)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json("ERRO");
            }

            db.Formas.Add(formas);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = formas.FormasId }, formas);
            return Json("OK");
        }

        // DELETE: api/Formas/5
        [ResponseType(typeof(Formas))]
        public IHttpActionResult DeleteFormas(int id)
        {
            Formas formas = db.Formas.Find(id);
            if (formas == null)
            {
                return NotFound();
            }

            db.Formas.Remove(formas);
            db.SaveChanges();

            return Ok(formas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FormasExists(int id)
        {
            return db.Formas.Count(e => e.FormasId == id) > 0;
        }
    }
}