using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MetroSub.Models;

namespace MetroSub.Controllers
{
    public class RutaController : ApiController
    {
        private Model db = new Model();

        // GET: api/Ruta
        public IQueryable<Rutas> GetRutas()
        {
            return db.Rutas;
        }

        // GET: api/Ruta/5
        [ResponseType(typeof(Rutas))]
        public async Task<IHttpActionResult> GetRutas(int id)
        {
            Rutas rutas = await db.Rutas.FindAsync(id);
            if (rutas == null)
            {
                return NotFound();
            }

            return Ok(rutas);
        }

        // PUT: api/Ruta/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRutas(int id, Rutas rutas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rutas.IdRuta)
            {
                return BadRequest();
            }

            db.Entry(rutas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutasExists(id))
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

        // POST: api/Ruta
        [ResponseType(typeof(Rutas))]
        public async Task<IHttpActionResult> PostRutas(Rutas rutas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rutas.Add(rutas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rutas.IdRuta }, rutas);
        }

        // DELETE: api/Ruta/5
        [ResponseType(typeof(Rutas))]
        public async Task<IHttpActionResult> DeleteRutas(int id)
        {
            Rutas rutas = await db.Rutas.FindAsync(id);
            if (rutas == null)
            {
                return NotFound();
            }

            db.Rutas.Remove(rutas);
            await db.SaveChangesAsync();

            return Ok(rutas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RutasExists(int id)
        {
            return db.Rutas.Count(e => e.IdRuta == id) > 0;
        }
    }
}