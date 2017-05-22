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
    public class ItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemsModels
        public ActionResult Index()
        {
            return View(db.ItemsModels.ToList());
        }

        // GET: ItemsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemsModel itemsModel = db.ItemsModels.Find(id);
            if (itemsModel == null)
            {
                return HttpNotFound();
            }
            return View(itemsModel);
        }

        // GET: ItemsModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Money")] ItemsModel itemsModel)
        {
            if (ModelState.IsValid)
            {
                db.ItemsModels.Add(itemsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemsModel);
        }

        // GET: ItemsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemsModel itemsModel = db.ItemsModels.Find(id);
            if (itemsModel == null)
            {
                return HttpNotFound();
            }
            return View(itemsModel);
        }

        // POST: ItemsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Money")] ItemsModel itemsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemsModel);
        }

        // GET: ItemsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemsModel itemsModel = db.ItemsModels.Find(id);
            if (itemsModel == null)
            {
                return HttpNotFound();
            }
            return View(itemsModel);
        }

        // POST: ItemsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemsModel itemsModel = db.ItemsModels.Find(id);
            db.ItemsModels.Remove(itemsModel);
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
