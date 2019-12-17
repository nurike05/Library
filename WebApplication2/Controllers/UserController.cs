﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                var users = db.Users.OrderBy(g => g.UsersName).ToList();
                return View(users);
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            //using (Model1 db = new Model1())
            //{
            //    //ViewBag.AuthorList = new SelectList(db.Authors.ToList(), "Id", "LastName");
            //    //ViewBag.GanreList = new SelectList(db.Ganres.ToList(), "Id", "Name");
            //}
            return View();

        }

        [HttpPost]
        public ActionResult Create(Users users)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Ganres.Add(ganres);
                    db.SaveChanges();
                }
                else return View(ganres);
            }
            return Redirect("Index");

        }


        [HttpGet]
        public ActionResult EditGanre(int? id)
        {
            Model1 db = new Model1();
            if (id == null)
            {
                return HttpNotFound();
            }
            Ganre ganre = db.Ganres.Find(id);
            if (ganre != null)
            {
                return View(ganre);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditGanre(Ganre ganre)
        {
            Model1 db = new Model1();
            db.Entry(ganre).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Model1 db = new Model1();
            Ganre b = db.Ganres.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Model1 db = new Model1();
            Ganre b = db.Ganres.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Ganres.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}