using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamConnect.Models
{
    public class Milestone
    {
        //team, I'm wondering if we want to create a separate table of AccomplishedMilestones (I just don't know how to generate that for the user automatically once they've reached the set milestone)
        //basic properties for each milestone
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MilestoneId { get; set; }

        [DisplayName("Reward")]
        public string MilestoneReward { get; set; }

        [Range(0, int.MaxValue)]
        [DisplayName("Points required")]
        public int MilestonePointsRequired { get; set; }



        //will be used to check if the goal has been accomplished
        public bool Accomplished { get; set; }

        //in case we would like to add a photo of the family doing their activity together in the future...
        public string PathToMileStonePhoto { get; set; }


        // connects each milestone to a particular user/family
        public string UserId { get; set; }
    }
}