﻿using Narail.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Narail.Controllers
{
    public class AuthorAdminController : Controller
    {
        NarailDBEntities db = new NarailDBEntities();
        public ActionResult Index()
        {
            return View(db.Author.ToList());
        }

        public ActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Author author, HttpPostedFileBase File)
        {
            var authorExist = db.Author.Any(m => m.Email == author.Email);

            if (authorExist == false)
            {
                author.AddedDate = DateTime.Now;
                author.AddedBy = "Mesut Kaya";
                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                    img.Resize(225, 180, false, false);
                    string tamyol = "~/images/users/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    author.Image = "/images/users/" + uzanti;
                }
                db.Author.Add(author);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }

            Author author = db.Author.Find(Id);
            db.Author.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}