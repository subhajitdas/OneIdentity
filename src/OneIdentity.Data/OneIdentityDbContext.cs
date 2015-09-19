using OneIdentity.Data.Configuration;
using OneIdentity.Domain.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OneIdentity.Data
{
    public class OneIdentityDbContext: DbContext
    {
        public OneIdentityDbContext()
            : base(nameOrConnectionString: "OneIdentityDbConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ApplicationConfiguration());
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new RedirectUrlConfiguration());
            modelBuilder.Configurations.Add(new ScopeConfiguration());
            modelBuilder.Configurations.Add(new AuthorizedGrantConfiguration());
            modelBuilder.Configurations.Add(new SignatureCredentialConfiguration());
            modelBuilder.Configurations.Add(new X509SignatureCredentialCofiguration());
            modelBuilder.Configurations.Add(new HMACSignatureCredentialCofiguration());
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RedirectUrl> RedirectUrls { get; set; }
        public DbSet<Scope> Scopes { get; set; }
        public DbSet<AuthorizedGrant> AuthorizedGrants { get; set; }
        public DbSet<SignatureCredential> SignatureCredentials { get; set; }
    }
}
