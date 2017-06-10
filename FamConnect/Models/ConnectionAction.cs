using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamConnect.Models
{
    public class ConnectionAction
    {
        //basic properties for each connection activity that will be logged
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ConnectionActionId { get; set; }

        //for the time being, there will be no title for the connection activity -- just the description
        [DisplayName("Description")]
        public string ConnectionActionDescription { get; set; }

        [Range(1, 10)]
        [DisplayName("Points")]
        public int PointsEarned { get; set; }

        //we didn't include this in our initial database design and don't have to use it, but thought it might be helpful
        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTime ConnectionActionDate { get; set; }

        //connects each connection action to the current family/User
        public string UserId { get; set; }

        //foreign key assigns a connection activity accomplished to a family member
        [ForeignKey("FamilyMember")]
        public int FamilyMemberId { get; set; }
        public virtual FamilyMember FamilyMember { get; set; }
    }
}