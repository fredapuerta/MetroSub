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
    public class EstacionController : ApiController
    {
        private Model db = new Model();

        // GET: api/Estacion
        public IQueryable<Estaciones> GetEstaciones()
        {
            return db.Estaciones;
        }

        // GET: api/Estacion/5
        [ResponseType(typeof(Estaciones))]
        public async Task<IHttpActionResult> GetEstaciones(int id)
        {
            Estaciones estaciones = await db.Estaciones.FindAsync(id);
            if (estaciones == null)
            {
                return NotFound();
            }

            return Ok(estaciones);
        }

        // PUT: api/Estacion/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstaciones(int id, Estaciones estaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estaciones.IdEstacion)
            {
                return BadRequest();
            }

            db.Entry(estaciones).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstacionesExists(id))
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

        // POST: api/Estacion
        [ResponseType(typeof(Estaciones))]
        public async Task<IHttpActionResult> PostEstaciones(Estaciones estaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estaciones.Add(estaciones);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = estaciones.IdEstacion }, estaciones);
        }

        // DELETE: api/Estacion/5
        [ResponseType(typeof(Estaciones))]
        public async Task<IHttpActionResult> DeleteEstaciones(int id)
        {
            Estaciones estaciones = await db.Estaciones.FindAsync(id);
            if (estaciones == null)
            {
                return NotFound();
            }

            db.Estaciones.Remove(estaciones);
            await db.SaveChangesAsync();

            return Ok(estaciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstacionesExists(int id)
        {
            return db.Estaciones.Count(e => e.IdEstacion == id) > 0;
        }
    }
}