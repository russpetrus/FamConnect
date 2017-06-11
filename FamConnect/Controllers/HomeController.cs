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
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            var family = new DashBoardViewModel();
            var currentFamily = User.Identity.GetUserId();
            family.FamilyID = currentFamily;
            family.FamilyMembers = db.FamilyMembers.ToList();
            family.Milestones = db.Milestones.ToList();
            family.ConnectionActions = db.ConnectionActions.ToList();
            return View(family);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}