using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamConnect.Models;
using Microsoft.AspNet.Identity;


namespace FamConnect.Controllers
{
    public class FamilyMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FamilyMembers
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            var familyMembers = from FamilyMember in db.FamilyMembers
                                where FamilyMember.UserId == currentUser
                                select FamilyMember;
            return View(familyMembers.ToList());
        }

        //to render index as partial view for the InitialCreate view upon first registering
        public ActionResult IndexCreateMembers()
        {
            var currentUser = User.Identity.GetUserId();
            var familyMembers = from FamilyMember in db.FamilyMembers
                                where FamilyMember.UserId == currentUser
                                select FamilyMember;
            return PartialView("_IndexCreateMembers",familyMembers);
        }
        // GET: FamilyMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyMember familyMember = db.FamilyMembers.Find(id);
            if (familyMember == null)
            {
                return HttpNotFound();
            }
            return View(familyMember);
        }

        // GET: FamilyMembers/Create
        public ActionResult Create()
        {
            return View();
            
        }

        // POST: FamilyMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FamilyMemberId,FirstName,MemberDOB,PathToMemberPhoto,UserId")] FamilyMember familyMember)
        {
            if (ModelState.IsValid)
            {
                familyMember.UserId = User.Identity.GetUserId();
                db.FamilyMembers.Add(familyMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(familyMember);
        
         }

        // Initial create action and view used upon first registering
        public ActionResult InitialCreate()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InitialCreate([Bind(Include = "FamilyMemberId,FirstName,MemberDOB,PathToMemberPhoto,UserId")] FamilyMember familyMember)
        {
            if (ModelState.IsValid)
            {
                familyMember.UserId = User.Identity.GetUserId();
                db.FamilyMembers.Add(familyMember);
                db.SaveChanges();
                return RedirectToAction("InitialCreate");
            }

            return View(familyMember);

        }


        // GET: FamilyMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyMember familyMember = db.FamilyMembers.Find(id);
            if (familyMember == null)
            {
                return HttpNotFound();
            }
            return View(familyMember);
        }

        // POST: FamilyMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FamilyMemberId,FirstName,MemberDOB,PathToMemberPhoto,UserId")] FamilyMember familyMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familyMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(familyMember);
        }

        // GET: FamilyMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyMember familyMember = db.FamilyMembers.Find(id);
            if (familyMember == null)
            {
                return HttpNotFound();
            }
            return View(familyMember);
        }

        // POST: FamilyMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FamilyMember familyMember = db.FamilyMembers.Find(id);
            db.FamilyMembers.Remove(familyMember);
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
