using OneIdentity.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneIdentity.Data.Configuration
{
    public class AuthorizedGrantConfiguration: EntityTypeConfiguration<AuthorizedGrant>
    {
        public AuthorizedGrantConfiguration()
        {
            this.HasKey(g => g.Id);
            this.Property(g => g.Id).IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(32);
            this.Property(g => g.Subject).IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(32);
            this.HasRequired(g => g.Application).WithMany().HasForeignKey(g=>g.ApplicationId);
            this.HasRequired(g => g.Client).WithMany().HasForeignKey(g => g.ClientId);
            this.HasRequired(g => g.RedirectUrl).WithMany().HasForeignKey(g => g.RedirectUrlId);
            this.HasMany(g => g.Scopes).WithMany().Map(m=>
            {
                m.MapLeftKey("AuthorizedGrantId");
                m.MapRightKey("ScopeId");
                m.ToTable("AuthorizedGrantScopes");
            });
        }
    }
}
