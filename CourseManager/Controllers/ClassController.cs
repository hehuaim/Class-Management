using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseManager.Models;

namespace CourseManager.Controllers
{
    public class ClassController : Controller
    {
        private CourseManagerEntities db = new CourseManagerEntities();

        // GET: Class
        public ActionResult Index()
        {

            return View(db.Classes.ToList());
        }

        // GET: Class/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        // GET: Class/Create
        public ActionResult Create()
        {
            var teachers = db.Teachers.ToList();

            ViewBag.teachers = teachers;
            return View();
        }

        // POST: Class/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TeacherId")] Classes classes)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(classes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classes);
        }

        // GET: Class/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var teachers = db.Teachers.ToList();

            ViewBag.teachers = teachers;
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        // POST: Class/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TeacherId")] Classes classes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classes);
        }

        // GET: Class/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classes classes = db.Classes.Find(id);
            db.Classes.Remove(classes);
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
