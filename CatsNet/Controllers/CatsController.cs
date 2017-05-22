using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CatsNet.Models;

namespace CatsNet.Controllers
{
    [Authorize]
    public class CatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CatsModels
        public ActionResult Index()
        {
            return View(db.CatsModels.ToList());
        }

        // GET: CatsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatsModel catsModel = db.CatsModels.Find(id);
            if (catsModel == null)
            {
                return HttpNotFound();
            }
            return View(catsModel);
        }

        // GET: CatsModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CatName,CatImage,MoneyToGive")] CatsModel catsModel)
        {
            if (ModelState.IsValid)
            {
                db.CatsModels.Add(catsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catsModel);
        }

        // GET: CatsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatsModel catsModel = db.CatsModels.Find(id);
            if (catsModel == null)
            {
                return HttpNotFound();
            }
            return View(catsModel);
        }

        // POST: CatsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CatName,CatImage,MoneyToGive")] CatsModel catsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catsModel);
        }

        // GET: CatsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatsModel catsModel = db.CatsModels.Find(id);
            if (catsModel == null)
            {
                return HttpNotFound();
            }
            return View(catsModel);
        }

        // POST: CatsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatsModel catsModel = db.CatsModels.Find(id);
            db.CatsModels.Remove(catsModel);
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
