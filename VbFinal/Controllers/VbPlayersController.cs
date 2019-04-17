using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VbFinal.Models;

namespace VbFinal.Controllers
{
    public class VbPlayersController : Controller
    {
        private DbModel db = new DbModel();
        private IMockVbPlayer db;

        public VbPlayersController()
        {
            this.db = new IDataVbPlayer();
        }

        public VbPlayersController(IMockVbPlayer db)
        {
            this.db = db;
        }


        // GET: VbPlayers
        public ActionResult Index()
        {
            var vbPlayers = db.VbPlayers;
            return View(vbPlayers.ToList());
        }

        // GET: VbPlayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VbPlayer vbPlayer = db.VbPlayers.Find(id);
            if (vbPlayer == null)
            {
                return HttpNotFound();
            }
            return View(vbPlayer);
        }

        // GET: VbPlayers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VbPlayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VbPlayerId,FirstName,Lastname,Photo,VbTeamId")] VbPlayer vbPlayer)
        {
            if (ModelState.IsValid)
            {
                db.VbPlayers.Add(vbPlayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vbPlayer);
        }

        // GET: VbPlayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VbPlayer vbPlayer = db.VbPlayers.Find(id);
            if (vbPlayer == null)
            {
                return HttpNotFound();
            }
            return View(vbPlayer);
        }

        // POST: VbPlayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VbPlayerId,FirstName,Lastname,Photo,VbTeamId")] VbPlayer vbPlayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vbPlayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vbPlayer);
        }

        // GET: VbPlayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VbPlayer vbPlayer = db.VbPlayers.Find(id);
            if (vbPlayer == null)
            {
                return HttpNotFound();
            }
            return View(vbPlayer);
        }

        // POST: VbPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VbPlayer vbPlayer = db.VbPlayers.Find(id);
            db.VbPlayers.Remove(vbPlayer);
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
