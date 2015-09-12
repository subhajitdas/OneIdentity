using OneIdentity.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace OneIdentity.Data.Configuration
{
    public class ApplicationConfiguration: EntityTypeConfiguration<Application>
    {
        public ApplicationConfiguration()
        {
            this.HasKey(a => a.Id);
            this.Property(a => a.Id).IsUnicode(false).IsRequired().HasMaxLength(10);
            this.Property(a => a.Name).IsRequired().HasMaxLength(127);
            this.Property(a => a.Description).IsOptional().HasMaxLength(1023);
            this.HasMany(a => a.Clients).WithRequired(c => c.Application).HasForeignKey(c => c.ApplicationId);
        }
    }
}
