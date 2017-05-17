using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pruebamvc.Controllers
{
    public class Default1Controller : Controller
    {
        private personaEntities3 db = new personaEntities3();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.persona.ToList());
        }

        public JsonResult load_personas()
        {
            //return db.persona.ToList();
            var datos = db.persona.ToList();
            return Json(new { response = datos }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(persona persona)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.persona.Add(persona);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    return Json(new { response = 1 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return View(persona);
                }
              
            }
            catch(Exception ex)
            {
                return Json(new { response = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
            //return View(persona);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            persona persona = db.persona.Find(id);
            var p = new Models.personaModels();

            if (persona == null)
            {
                return HttpNotFound();
            }

            //seteamos los datos del modelo con lo que genero la consulta
            p.nombre = persona.nombre; p.apellidos = persona.apellidos; p.telefono = persona.telefono; p.id = persona.id;
            return View(p);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            persona persona = db.persona.Find(id);
            db.persona.Remove(persona);
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