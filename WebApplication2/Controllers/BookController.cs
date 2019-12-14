﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                var books = db.Books.OrderBy(b=>b.Title).ToList();

                //ViewBag.AuthorName = db.Authors.Select(a => a.FirstName).FirstOrDefault();

                return View(books);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (Model1 db = new Model1())
            {
                ViewBag.AuthorList = new SelectList(db.Authors.ToList(), "Id", "LastName");
                ViewBag.GanreList = new SelectList(db.Ganres.ToList(), "Id", "Name");
            }
            return View();
            
        }

        [HttpPost]
        public ActionResult Create(Books book)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                }
                else return View(book);
            }
            return Redirect("Index");

        }

        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}