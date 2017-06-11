using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FamConnect.Models
{
    public class DashBoardViewModel
    {
        public IEnumerable<ApplicationUser> Families { get; set; }
        public string FamilyID { get; set; }
        public IEnumerable <FamilyMember> FamilyMembers { get; set; }
        public IEnumerable <Milestone> Milestones { get; set; }
        public IEnumerable <ConnectionAction> ConnectionActions { get; set; } 
    }
}