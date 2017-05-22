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
    public class FoodController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Food
        public ActionResult Index()
        {
            return View(db.FoodModels.ToList());
        }

        // GET: Food/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodModel foodModel = db.FoodModels.Find(id);
            if (foodModel == null)
            {
                return HttpNotFound();
            }
            return View(foodModel);
        }

        // GET: Food/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Food/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Cost,Type,FoodIsOut,Duration,TimeStart,TimeFinish")] FoodModel foodModel)
        {
            if (ModelState.IsValid)
            {
                db.FoodModels.Add(foodModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodModel);
        }

        // GET: Food/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodModel foodModel = db.FoodModels.Find(id);
            if (foodModel == null)
            {
                return HttpNotFound();
            }
            return View(foodModel);
        }

        // POST: Food/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Cost,Type,FoodIsOut,Duration,TimeStart,TimeFinish")] FoodModel foodModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodModel);
        }

        // GET: Food/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodModel foodModel = db.FoodModels.Find(id);
            if (foodModel == null)
            {
                return HttpNotFound();
            }
            return View(foodModel);
        }

        // POST: Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodModel foodModel = db.FoodModels.Find(id);
            db.FoodModels.Remove(foodModel);
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
