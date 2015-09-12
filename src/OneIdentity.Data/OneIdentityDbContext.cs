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
            modelBuilder.Configurations.Add(new ScopeConfiguration());
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Scope> Scopes { get; set; }
    }
}
