namespace Intandoyesizwe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdmissionApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        grade = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                        prevGrade = c.Int(nullable: false),
                        prevGradeYear = c.Int(nullable: false),
                        date_ = c.DateTime(nullable: false),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        homeNo = c.String(),
                        emergNo = c.String(),
                        learnerNo = c.String(),
                        Email = c.String(),
                        homeLanguage = c.String(),
                        deceasedParent = c.String(),
                        transportMode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdmissionApplications", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Correspondences",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        title = c.String(),
                        lastName = c.String(),
                        firstLine = c.String(),
                        city = c.String(),
                        code = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdmissionApplications", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        title = c.String(),
                        initials = c.String(),
                        lastName = c.String(),
                        firstName = c.String(),
                        idNo = c.String(),
                        occupation = c.String(),
                        resideswith = c.String(),
                        relationship = c.String(),
                        numberOfOtherChildren = c.Int(nullable: false),
                        familyPosition = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdmissionApplications", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        surname = c.String(),
                        initials = c.String(),
                        nickname = c.String(),
                        firstName = c.String(),
                        otherNames = c.String(),
                        idNo = c.String(),
                        gender = c.String(),
                        dob = c.DateTime(nullable: false),
                        race = c.String(),
                        dexterity = c.String(),
                        regSocGrant = c.String(),
                        recSocGrant = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdmissionApplications", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PhysicalAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        street = c.String(),
                        suburb = c.String(),
                        city = c.String(),
                        code = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdmissionApplications", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PrevSchools",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        schoolName = c.String(),
                        province = c.String(),
                        street = c.String(),
                        suburb = c.String(),
                        city = c.String(),
                        code = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdmissionApplications", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Rejecteds",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        reason = c.String(nullable: false),
                        date_ = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdmissionApplications", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Rejecteds", "Id", "dbo.AdmissionApplications");
            DropForeignKey("dbo.PrevSchools", "Id", "dbo.AdmissionApplications");
            DropForeignKey("dbo.PhysicalAddresses", "Id", "dbo.AdmissionApplications");
            DropForeignKey("dbo.Personals", "Id", "dbo.AdmissionApplications");
            DropForeignKey("dbo.Parents", "Id", "dbo.AdmissionApplications");
            DropForeignKey("dbo.Correspondences", "Id", "dbo.AdmissionApplications");
            DropForeignKey("dbo.Contacts", "Id", "dbo.AdmissionApplications");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Rejecteds", new[] { "Id" });
            DropIndex("dbo.PrevSchools", new[] { "Id" });
            DropIndex("dbo.PhysicalAddresses", new[] { "Id" });
            DropIndex("dbo.Personals", new[] { "Id" });
            DropIndex("dbo.Parents", new[] { "Id" });
            DropIndex("dbo.Correspondences", new[] { "Id" });
            DropIndex("dbo.Contacts", new[] { "Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rejecteds");
            DropTable("dbo.PrevSchools");
            DropTable("dbo.PhysicalAddresses");
            DropTable("dbo.Personals");
            DropTable("dbo.Parents");
            DropTable("dbo.Correspondences");
            DropTable("dbo.Contacts");
            DropTable("dbo.AdmissionApplications");
        }
    }
}
