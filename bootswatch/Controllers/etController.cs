using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bootswatch.Models;
using bootswatch.repositories;

namespace bootswatch.Controllers
{ 
    public class etController : Controller
    {
        private EtudiantDBContext db = new EtudiantDBContext();
        private fonctionRep fr = new fonctionRep();
        //
        // GET: /et/
        
        public ViewResult Index()
        {
            return View(db.Etudiants.ToList());
        }
        public ViewResult tr() {
            Etudiant[] trier = fr.Trier();
            return View(trier.ToList());
        }

        //
        // GET: /et/Details/5

        public ViewResult Details(int id)
        {
            Etudiant etudiant = db.Etudiants.Find(id);
            return View(etudiant);
        }

        //
        // GET: /et/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /et/Create

        [HttpPost]
        public ActionResult Create(Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Etudiants.Add(etudiant);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(etudiant);
        }
        
        //
        // GET: /et/Edit/5
 
        public ActionResult Edit(int id)
        {
            Etudiant etudiant = db.Etudiants.Find(id);
            return View(etudiant);
        }

        //
        // POST: /et/Edit/5

        [HttpPost]
        public ActionResult Edit(Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etudiant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etudiant);
        }

        //
        // GET: /et/Delete/5
 
        public ActionResult Delete(int id)
        {
            Etudiant etudiant = db.Etudiants.Find(id);
            return View(etudiant);
        }

        //
        // POST: /et/Delete/5
        public ActionResult search() {
            string mots = Request.Form["tt"];
            ViewBag.mots = mots;
            Etudiant et = fr.getEtByNom(mots);
            ViewBag.et = et;
            return RedirectToAction("details", new { id = et.Id_Et });
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Etudiant etudiant = db.Etudiants.Find(id);
            db.Etudiants.Remove(etudiant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}