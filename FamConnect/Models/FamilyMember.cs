using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamConnect.Models
{
    public class FamilyMember
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int FamilyMemberId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Birthday")]
        public DateTime MemberDOB { get; set; }

        [DisplayName("Image")]
        public string PathToMemberPhoto { get; set; }

        //public string UserId will connect each family member to a particular user
        public string UserId { get; set; }

        //allows each user to hold a list of connectionactions
        public virtual ICollection<ConnectionAction> ConnectionAction { get; set; }

    }
}