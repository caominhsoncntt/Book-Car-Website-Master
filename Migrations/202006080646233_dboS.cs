namespace BookCarProjectMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dboS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.BookCars",
                c => new
                    {
                        BookCarsId = c.Int(nullable: false, identity: true),
                        DateBookCar = c.DateTime(nullable: false),
                        TotalRental = c.Decimal(nullable: false, precision: 19, scale: 1),
                        DateOfReceive = c.DateTime(),
                        DateReturn = c.DateTime(),
                        PaymentStatus = c.Boolean(),
                        FullNameUser = c.String(nullable: false, maxLength: 60),
                        CardIDUser = c.String(nullable: false, maxLength: 20, unicode: false),
                        AddressUser = c.String(nullable: false, maxLength: 128),
                        NumberPhoneUser = c.String(nullable: false, maxLength: 12, unicode: false),
                        EmailUser = c.String(maxLength: 128),
                        CarProductsId = c.Int(),
                    })
                .PrimaryKey(t => t.BookCarsId)
                .ForeignKey("dbo.CarProducts", t => t.CarProductsId, cascadeDelete: true)
                .Index(t => t.CarProductsId);
            
            CreateTable(
                "dbo.CarProducts",
                c => new
                    {
                        CarProductsId = c.Int(nullable: false, identity: true),
                        ModelCar = c.String(nullable: false, maxLength: 50),
                        CarColor = c.String(maxLength: 20),
                        NumberOfSeats = c.Int(),
                        ImageFont = c.String(maxLength: 128),
                        ImageBack = c.String(maxLength: 128),
                        Keyword = c.String(maxLength: 50),
                        NumberOfCars = c.Int(nullable: false),
                        Info = c.String(),
                        ActionProduct = c.Boolean(),
                        RentCost = c.Decimal(nullable: false, precision: 19, scale: 0),
                        CarProductStatus = c.Boolean(nullable: false),
                        CarCategoryId = c.Int(),
                        FuelsId = c.Int(),
                        GearBoxsId = c.Int(),
                    })
                .PrimaryKey(t => t.CarProductsId)
                .ForeignKey("dbo.CarCategories", t => t.CarCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Fuels", t => t.FuelsId, cascadeDelete: true)
                .ForeignKey("dbo.GearBoxs", t => t.GearBoxsId, cascadeDelete: true)
                .Index(t => t.CarCategoryId)
                .Index(t => t.FuelsId)
                .Index(t => t.GearBoxsId);
            
            CreateTable(
                "dbo.CarCategories",
                c => new
                    {
                        CarCategoryId = c.Int(nullable: false, identity: true),
                        NameCarCategory = c.String(nullable: false, maxLength: 50),
                        CarCategoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CarCategoryId);
            
            CreateTable(
                "dbo.Fuels",
                c => new
                    {
                        FuelsId = c.Int(nullable: false, identity: true),
                        NameFuel = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FuelsId);
            
            CreateTable(
                "dbo.GearBoxs",
                c => new
                    {
                        GearBoxsId = c.Int(nullable: false, identity: true),
                        NameGearBox = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GearBoxsId);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarProducts", "GearBoxsId", "dbo.GearBoxs");
            DropForeignKey("dbo.CarProducts", "FuelsId", "dbo.Fuels");
            DropForeignKey("dbo.CarProducts", "CarCategoryId", "dbo.CarCategories");
            DropForeignKey("dbo.BookCars", "CarProductsId", "dbo.CarProducts");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.CarProducts", new[] { "GearBoxsId" });
            DropIndex("dbo.CarProducts", new[] { "FuelsId" });
            DropIndex("dbo.CarProducts", new[] { "CarCategoryId" });
            DropIndex("dbo.BookCars", new[] { "CarProductsId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.GearBoxs");
            DropTable("dbo.Fuels");
            DropTable("dbo.CarCategories");
            DropTable("dbo.CarProducts");
            DropTable("dbo.BookCars");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
        }
    }
}
