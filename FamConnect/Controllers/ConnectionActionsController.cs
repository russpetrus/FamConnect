﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamConnect.Models;

namespace FamConnect.Controllers
{
    public class ConnectionActionsController : Controller
    {
        private FamConnectContext db = new FamConnectContext();

        // GET: ConnectionActions
        public ActionResult Index()
        {
            var connectionActions = db.ConnectionActions.Include(c => c.FamilyMember);
            return View(connectionActions.ToList());
        }

        // GET: ConnectionActions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConnectionAction connectionAction = db.ConnectionActions.Find(id);
            if (connectionAction == null)
            {
                return HttpNotFound();
            }
            return View(connectionAction);
        }

        // GET: ConnectionActions/Create
        public ActionResult Create()
        {
            ViewBag.FamilyMemberId = new SelectList(db.FamilyMembers, "FamilyMemberId", "FirstName");
            return View();
        }

        // POST: ConnectionActions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConnectionActionId,ConnectionActionDescription,PointsEarned,ConnectionActionDate,UserId,FamilyMemberId")] ConnectionAction connectionAction)
        {
            if (ModelState.IsValid)
            {
                db.ConnectionActions.Add(connectionAction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FamilyMemberId = new SelectList(db.FamilyMembers, "FamilyMemberId", "FirstName", connectionAction.FamilyMemberId);
            return View(connectionAction);
        }

        // GET: ConnectionActions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConnectionAction connectionAction = db.ConnectionActions.Find(id);
            if (connectionAction == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyMemberId = new SelectList(db.FamilyMembers, "FamilyMemberId", "FirstName", connectionAction.FamilyMemberId);
            return View(connectionAction);
        }

        // POST: ConnectionActions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConnectionActionId,ConnectionActionDescription,PointsEarned,ConnectionActionDate,UserId,FamilyMemberId")] ConnectionAction connectionAction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(connectionAction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FamilyMemberId = new SelectList(db.FamilyMembers, "FamilyMemberId", "FirstName", connectionAction.FamilyMemberId);
            return View(connectionAction);
        }

        // GET: ConnectionActions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConnectionAction connectionAction = db.ConnectionActions.Find(id);
            if (connectionAction == null)
            {
                return HttpNotFound();
            }
            return View(connectionAction);
        }

        // POST: ConnectionActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConnectionAction connectionAction = db.ConnectionActions.Find(id);
            db.ConnectionActions.Remove(connectionAction);
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