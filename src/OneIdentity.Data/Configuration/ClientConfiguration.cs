using OneIdentity.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace OneIdentity.Data.Configuration
{
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).IsUnicode(false).IsRequired().HasMaxLength(10);
            this.Property(c => c.Name).IsRequired().HasMaxLength(127);
            this.Property(c => c.Description).IsOptional().HasMaxLength(1023);
            this.HasMany(c => c.AllowedScopes).WithMany(s => s.Clients).Map(m =>
                {
                    m.MapLeftKey("ClientId");
                    m.MapRightKey("ScopeId");
                    m.ToTable("ClientScopes");
                });
        }
    }
}