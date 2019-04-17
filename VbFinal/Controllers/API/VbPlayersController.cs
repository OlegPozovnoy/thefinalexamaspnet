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
using VbFinal.Models;

namespace VbFinal.Controllers.API
{
    public class VbPlayersController : ApiController
    {
        private Models.DbModel db = new Models.DbModel();

        // GET: api/VbPlayers
        public IQueryable<VbPlayer> GetVbPlayers()
        {
            return db.VbPlayers;
        }

        // GET: api/VbPlayers/5
        [ResponseType(typeof(VbPlayer))]
        public IHttpActionResult GetVbPlayer(int id)
        {
            VbPlayer vbPlayer = db.VbPlayers.Find(id);
            if (vbPlayer == null)
            {
                return NotFound();
            }

            return Ok(vbPlayer);
        }

        // PUT: api/VbPlayers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVbPlayer(int id, VbPlayer vbPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vbPlayer.VbPlayerId)
            {
                return BadRequest();
            }

            db.Entry(vbPlayer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VbPlayerExists(id))
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

        // POST: api/VbPlayers
        [ResponseType(typeof(VbPlayer))]
        public IHttpActionResult PostVbPlayer(VbPlayer vbPlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VbPlayers.Add(vbPlayer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vbPlayer.VbPlayerId }, vbPlayer);
        }

        // DELETE: api/VbPlayers/5
        [ResponseType(typeof(VbPlayer))]
        public IHttpActionResult DeleteVbPlayer(int id)
        {
            VbPlayer vbPlayer = db.VbPlayers.Find(id);
            if (vbPlayer == null)
            {
                return NotFound();
            }

            db.VbPlayers.Remove(vbPlayer);
            db.SaveChanges();

            return Ok(vbPlayer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VbPlayerExists(int id)
        {
            return db.VbPlayers.Count(e => e.VbPlayerId == id) > 0;
        }
    }
}