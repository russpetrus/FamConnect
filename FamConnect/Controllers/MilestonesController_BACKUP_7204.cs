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
    public class MilestonesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Milestones
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            var milestones = from Milestone in db.Milestones
                             where Milestone.UserId == currentUser
                             select Milestone;
            return View(milestones.ToList());
        }

        //// GET: Milestones Point Goal
        //public ActionResult GetMilestoneValue()
        //{
        //    var currentUser = User.Identity.GetUserId();
        //    var milestones = from Milestone in db.Milestones
        //                     where Milestone.UserId == currentUser
        //                     select Milestone;
        //   var Goal = milestones.OrderByDescending(p => p.MilestoneId).First().MilestonePointsRequired;

        // ViewBag.MilestoneGoal = Goal;
        //    return PartialView("_ShowMileStoneValue");
        //}

        // GET: Milestones Points Required
        public ActionResult GetMilestoneValue()
        {
            var currentUser = User.Identity.GetUserId();
            var milestones = from Milestone in db.Milestones
                             where Milestone.UserId == currentUser
                             select Milestone.MilestonePointsRequired;
            if (milestones.Any())
            {
                var goal = milestones.ToList().Last();
                ViewBag.MilestoneGoal = goal;
                return PartialView("_ShowMileStoneValue");
            }
            else
            {
                ViewBag.MilestoneGoal = 0;
                return PartialView("_ShowMileStoneValue");
            }

        }

        // GET: Milestones Reward
        public ActionResult GetMilestoneReward()
        {
            var currentUser = User.Identity.GetUserId();
            var milestones = from Milestone in db.Milestones
                             where Milestone.UserId == currentUser
                             select Milestone.MilestoneReward;
            if (milestones.Any())
            {
                var goal = milestones.ToList().Last();
                ViewBag.MilestoneReward = goal;
                return PartialView("_ShowMileStoneGoal");
            }
            else
            {
                ViewBag.MilestoneReward = "No Milestone set";
                return PartialView("_ShowMileStoneGoal");
            }

        }

<<<<<<< HEAD

    // GET: Milestones/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
=======
        //actions for creating the first milestone upon initial registration
        public ActionResult InitialCreate()
        {
            return View();
        }

        // POST: Milestones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InitialCreate([Bind(Include = "MilestoneId,MilestoneReward,MilestonePointsRequired,Accomplished,PathToMileStonePhoto,UserId")] Milestone milestone)
        {
            if (ModelState.IsValid)
            {
                milestone.UserId = User.Identity.GetUserId();
                milestone.Accomplished = false;
                db.Milestones.Add(milestone);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(milestone);
        }

        // GET: Milestones/Edit/5
        public ActionResult Edit(int? id)
>>>>>>> master
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Milestone milestone = db.Milestones.Find(id);
        if (milestone == null)
        {
            return HttpNotFound();
        }
        return View(milestone);
    }

    // GET: Milestones/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Milestones/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "MilestoneId,MilestoneReward,MilestonePointsRequired,Accomplished,PathToMileStonePhoto,UserId")] Milestone milestone)
    {
        if (ModelState.IsValid)
        {
            milestone.UserId = User.Identity.GetUserId();
            milestone.Accomplished = false;
            db.Milestones.Add(milestone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(milestone);
    }

    // GET: Milestones/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Milestone milestone = db.Milestones.Find(id);
        if (milestone == null)
        {
            return HttpNotFound();
        }
        return View(milestone);
    }

    // POST: Milestones/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "MilestoneId,MilestoneReward,MilestonePointsRequired,Accomplished,PathToMileStonePhoto,UserId")] Milestone milestone)
    {
        if (ModelState.IsValid)
        {
            db.Entry(milestone).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(milestone);
    }

    // GET: Milestones/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Milestone milestone = db.Milestones.Find(id);
        if (milestone == null)
        {
            return HttpNotFound();
        }
        return View(milestone);
    }

    // POST: Milestones/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Milestone milestone = db.Milestones.Find(id);
        db.Milestones.Remove(milestone);
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
