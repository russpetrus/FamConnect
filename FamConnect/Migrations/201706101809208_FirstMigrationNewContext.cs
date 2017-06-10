namespace FamConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigrationNewContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConnectionActions",
                c => new
                    {
                        ConnectionActionId = c.Int(nullable: false, identity: true),
                        ConnectionActionDescription = c.String(),
                        PointsEarned = c.Int(nullable: false),
                        ConnectionActionDate = c.DateTime(nullable: false),
                        UserId = c.String(),
                        FamilyMemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConnectionActionId)
                .ForeignKey("dbo.FamilyMembers", t => t.FamilyMemberId, cascadeDelete: true)
                .Index(t => t.FamilyMemberId);
            
            CreateTable(
                "dbo.FamilyMembers",
                c => new
                    {
                        FamilyMemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MemberDOB = c.DateTime(nullable: false),
                        PathToMemberPhoto = c.String(),
                        UserId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FamilyMemberId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Milestones",
                c => new
                    {
                        MilestoneId = c.Int(nullable: false, identity: true),
                        MilestoneReward = c.String(),
                        MilestonePointsRequired = c.Int(nullable: false),
                        Accomplished = c.Boolean(nullable: false),
                        PathToMileStonePhoto = c.String(),
                        UserId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MilestoneId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "FamilyName", c => c.String());
            AddColumn("dbo.AspNetUsers", "PathToFamilyPicture", c => c.String());
            AddColumn("dbo.AspNetUsers", "FamilyPointsEarned", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Milestones", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FamilyMembers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConnectionActions", "FamilyMemberId", "dbo.FamilyMembers");
            DropIndex("dbo.Milestones", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ConnectionActions", new[] { "FamilyMemberId" });
            DropColumn("dbo.AspNetUsers", "FamilyPointsEarned");
            DropColumn("dbo.AspNetUsers", "PathToFamilyPicture");
            DropColumn("dbo.AspNetUsers", "FamilyName");
            DropTable("dbo.Milestones");
            DropTable("dbo.FamilyMembers");
            DropTable("dbo.ConnectionActions");
        }
    }
}
