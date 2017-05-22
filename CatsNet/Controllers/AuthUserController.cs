using CatsNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace CatsNet.Controllers
{
    [Authorize]
    public class AuthUserController : Controller
    {
        //top level variables
        int money;
        // GET: AuthUser
        public ActionResult Index()
        {
            //check to see how much money this user has
            //call to data
            var itemModel = new ItemsModel();
            {
                if (itemModel.Username == User.Identity.Name)
                {
                    money = itemModel.Money;
                }
            }
            //return that to the ViewBag
            ViewBag.MoneyAmount = money;

            //is the cat bowl empty?
            var currentTime = DateTime.Now;

            var foodModel = new FoodModel();
       
            //finish methods for food is out, food is empty.
            
            
            //if (foodModel.FoodIsOut == true)
            //    {
            //        if (foodModel.TimeFinish < currentTime)
            //    }
           

            return View();
        }

        // GET: AuthUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
