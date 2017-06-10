using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace FamConnect.Models
{
    public class DashBoardViewModel
    {
        public ApplicationUser currentUser { get; set; }
        public ICollection <FamilyMember> FamilyMembers { get; set; }
        public ICollection <Milestone> Milestones { get; set; }
        public ICollection <ConnectionAction> ConnectionActions { get; set; } 
    }
}