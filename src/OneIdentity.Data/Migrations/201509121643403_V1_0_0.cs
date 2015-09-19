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
                        Audiance = c.String(nullable: false, maxLength: 255),
                        TokenLifetime = c.Int(nullable: false),
                        AllowRefreshToken = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        SignatureCredentialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SignatureCredentials", t => t.SignatureCredentialId, cascadeDelete: true)
                .Index(t => t.SignatureCredentialId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10, unicode: false),
                        Name = c.String(nullable: false, maxLength: 127),
                        Description = c.String(maxLength: 1023),
                        Flow = c.Byte(nullable: false),
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
                "dbo.RedirectUrls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.String(nullable: false, maxLength: 10, unicode: false),
                        Url = c.String(nullable: false, maxLength: 2047),
                        Description = c.String(maxLength: 1023),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.SignatureCredentials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 127),
                        Key = c.Binary(maxLength: 512),
                        CertificateLocation = c.Int(),
                        CertificateStore = c.Int(),
                        FindCertificateBy = c.Int(),
                        CertificateFindValue = c.String(maxLength: 255),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuthorizedGrants",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 32, fixedLength: true, unicode: false),
                        Subject = c.String(nullable: false, maxLength: 32, fixedLength: true, unicode: false),
                        ApplicationId = c.String(nullable: false, maxLength: 10, unicode: false),
                        ClientId = c.String(nullable: false, maxLength: 10, unicode: false),
                        RedirectUrlId = c.Int(nullable: false),
                        Type = c.Byte(nullable: false),
                        IssuedOnUtc = c.DateTime(nullable: false),
                        ExpiresOnUtc = c.DateTime(nullable: false),
                        IsRevoked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.RedirectUrls", t => t.RedirectUrlId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.ClientId)
                .Index(t => t.RedirectUrlId);
            
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
            
            CreateTable(
                "dbo.AuthorizedGrantScopes",
                c => new
                    {
                        AuthorizedGrantId = c.String(nullable: false, maxLength: 32, fixedLength: true, unicode: false),
                        ScopeId = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => new { t.AuthorizedGrantId, t.ScopeId })
                .ForeignKey("dbo.AuthorizedGrants", t => t.AuthorizedGrantId)
                .ForeignKey("dbo.Scopes", t => t.ScopeId)
                .Index(t => t.AuthorizedGrantId)
                .Index(t => t.ScopeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthorizedGrantScopes", "ScopeId", "dbo.Scopes");
            DropForeignKey("dbo.AuthorizedGrantScopes", "AuthorizedGrantId", "dbo.AuthorizedGrants");
            DropForeignKey("dbo.AuthorizedGrants", "RedirectUrlId", "dbo.RedirectUrls");
            DropForeignKey("dbo.AuthorizedGrants", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.AuthorizedGrants", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.Applications", "SignatureCredentialId", "dbo.SignatureCredentials");
            DropForeignKey("dbo.Scopes", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.Clients", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.RedirectUrls", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientScopes", "ScopeId", "dbo.Scopes");
            DropForeignKey("dbo.ClientScopes", "ClientId", "dbo.Clients");
            DropIndex("dbo.AuthorizedGrantScopes", new[] { "ScopeId" });
            DropIndex("dbo.AuthorizedGrantScopes", new[] { "AuthorizedGrantId" });
            DropIndex("dbo.ClientScopes", new[] { "ScopeId" });
            DropIndex("dbo.ClientScopes", new[] { "ClientId" });
            DropIndex("dbo.AuthorizedGrants", new[] { "RedirectUrlId" });
            DropIndex("dbo.AuthorizedGrants", new[] { "ClientId" });
            DropIndex("dbo.AuthorizedGrants", new[] { "ApplicationId" });
            DropIndex("dbo.RedirectUrls", new[] { "ClientId" });
            DropIndex("dbo.Scopes", new[] { "ApplicationId" });
            DropIndex("dbo.Clients", new[] { "ApplicationId" });
            DropIndex("dbo.Applications", new[] { "SignatureCredentialId" });
            DropTable("dbo.AuthorizedGrantScopes");
            DropTable("dbo.ClientScopes");
            DropTable("dbo.AuthorizedGrants");
            DropTable("dbo.SignatureCredentials");
            DropTable("dbo.RedirectUrls");
            DropTable("dbo.Scopes");
            DropTable("dbo.Clients");
            DropTable("dbo.Applications");
        }
    }
}
