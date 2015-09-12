namespace OneIdentity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1_0_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10, unicode: false),
                        Name = c.String(nullable: false, maxLength: 127),
                        Description = c.String(maxLength: 1023),
                        Audiance = c.String(),
                        TokenLifetime = c.Int(nullable: false),
                        AllowRefreshToken = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10, unicode: false),
                        Name = c.String(nullable: false, maxLength: 127),
                        Description = c.String(maxLength: 1023),
                        Flow = c.Byte(nullable: false),
                        RedirectUri = c.String(nullable: false, maxLength: 2047),
                        AllowRefreshToken = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ApplicationId = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Scopes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10, unicode: false),
                        Name = c.String(nullable: false, maxLength: 127),
                        Description = c.String(maxLength: 1023),
                        ApplicationId = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.ClientScopes",
                c => new
                    {
                        ClientId = c.String(nullable: false, maxLength: 10, unicode: false),
                        ScopeId = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => new { t.ClientId, t.ScopeId })
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Scopes", t => t.ScopeId)
                .Index(t => t.ClientId)
                .Index(t => t.ScopeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scopes", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.Clients", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.ClientScopes", "ScopeId", "dbo.Scopes");
            DropForeignKey("dbo.ClientScopes", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientScopes", new[] { "ScopeId" });
            DropIndex("dbo.ClientScopes", new[] { "ClientId" });
            DropIndex("dbo.Scopes", new[] { "ApplicationId" });
            DropIndex("dbo.Clients", new[] { "ApplicationId" });
            DropTable("dbo.ClientScopes");
            DropTable("dbo.Scopes");
            DropTable("dbo.Clients");
            DropTable("dbo.Applications");
        }
    }
}
