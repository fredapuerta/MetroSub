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
    public class RutaEstacionController : ApiController
    {
        private Model db = new Model();

        // GET: api/RutaEstacion
        public IQueryable<RutasEstaciones> GetRutasEstaciones()
        {
            return db.RutasEstaciones;
        }

        // GET: api/RutaEstacion/5
        [ResponseType(typeof(RutasEstaciones))]
        public async Task<IHttpActionResult> GetRutasEstaciones(int id)
        {
            RutasEstaciones rutasEstaciones = await db.RutasEstaciones.FindAsync(id);
            if (rutasEstaciones == null)
            {
                return NotFound();
            }

            return Ok(rutasEstaciones);
        }

        // PUT: api/RutaEstacion/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRutasEstaciones(int id, RutasEstaciones rutasEstaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rutasEstaciones.IdRutasEstaciones)
            {
                return BadRequest();
            }

            db.Entry(rutasEstaciones).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutasEstacionesExists(id))
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

        // POST: api/RutaEstacion
        [ResponseType(typeof(RutasEstaciones))]
        public async Task<IHttpActionResult> PostRutasEstaciones(RutasEstaciones rutasEstaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RutasEstaciones.Add(rutasEstaciones);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rutasEstaciones.IdRutasEstaciones }, rutasEstaciones);
        }

        // DELETE: api/RutaEstacion/5
        [ResponseType(typeof(RutasEstaciones))]
        public async Task<IHttpActionResult> DeleteRutasEstaciones(int id)
        {
            RutasEstaciones rutasEstaciones = await db.RutasEstaciones.FindAsync(id);
            if (rutasEstaciones == null)
            {
                return NotFound();
            }

            db.RutasEstaciones.Remove(rutasEstaciones);
            await db.SaveChangesAsync();

            return Ok(rutasEstaciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RutasEstacionesExists(int id)
        {
            return db.RutasEstaciones.Count(e => e.IdRutasEstaciones == id) > 0;
        }
    }
}