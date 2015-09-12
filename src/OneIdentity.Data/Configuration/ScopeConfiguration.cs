using OneIdentity.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace OneIdentity.Data.Configuration
{
    public class ScopeConfiguration : EntityTypeConfiguration<Scope>
    {
        public ScopeConfiguration()
        {
            this.HasKey(s => s.Id);
            this.Property(s => s.Id).IsUnicode(false).IsRequired().HasMaxLength(10);
            this.Property(s => s.Name).IsRequired().HasMaxLength(127);
            this.Property(s => s.Description).IsOptional().HasMaxLength(1023);
        }
    }
}
