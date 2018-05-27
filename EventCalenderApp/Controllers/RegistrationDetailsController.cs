using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventCalenderApp.Context;
using EventCalenderApp.Models;
using EventCalenderApp.Models.ViewModels;

namespace EventCalenderApp.Controllers
{
    public class RegistrationDetailsController : Controller
    {
        private ContextManager db = new ContextManager();
        [Authorize]
        // GET: RegistrationDetails
        public ActionResult Index()
        {
            return View(db.RegistrationDetails.ToList());
        }
        
        // GET: RegistrationDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationDetail registrationDetail = db.RegistrationDetails.Find(id);
            var vm=new RegistrationDetailViewModel();
            if (registrationDetail != null) 
            {
                vm.Id = registrationDetail.Id;
                vm.Name = registrationDetail.Name;
                vm.Email = registrationDetail.Email;
                vm.MobileNo = registrationDetail.MobileNo;
                vm.Address = registrationDetail.Address;
            }
            
            if (registrationDetail == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: RegistrationDetails/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create([Bind(Include = "Id,Name,Email,MobileNo,Address")] RegistrationDetailViewModel registrationDetail)
        {
            if (ModelState.IsValid)
            {
                var model=new RegistrationDetail();
                registrationDetail.Id = model.Id;
                model.Name = registrationDetail.Name;
                model.Email = registrationDetail.Email;
                model.MobileNo = registrationDetail.MobileNo;
                model.Address = registrationDetail.Address;
                db.RegistrationDetails.Add(model);
                db.SaveChanges();
                TempData["msg"] = "Registration information has been successfully saved.";


                return RedirectToAction("Details","RegistrationDetails", new { id = model.Id });
            }

            return View("Error");
        }

        // GET: RegistrationDetails/Edit/5
        [AllowAnonymous]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationDetail registrationDetail = db.RegistrationDetails.Find(id);
            if (registrationDetail == null)
            {
                return HttpNotFound();
            }
            return View(registrationDetail);
        }

        // POST: RegistrationDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,MobileNo,Address")] RegistrationDetail registrationDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrationDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details","RegistrationDetails",new {id=registrationDetail.Id});
            }
            return View("Error");
        }

        // GET: RegistrationDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationDetail registrationDetail = db.RegistrationDetails.Find(id);
            if (registrationDetail == null)
            {
                return HttpNotFound();
            }
            return View(registrationDetail);
        }

        // POST: RegistrationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistrationDetail registrationDetail = db.RegistrationDetails.Find(id);
            db.RegistrationDetails.Remove(registrationDetail);
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
