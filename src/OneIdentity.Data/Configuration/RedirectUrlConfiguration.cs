using OneIdentity.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneIdentity.Data.Configuration
{
    public class RedirectUrlConfiguration:EntityTypeConfiguration<RedirectUrl>
    {
        public RedirectUrlConfiguration()
        {
            this.Property(r => r.Url).IsRequired().HasMaxLength(2047);
            this.Property(r => r.Description).IsOptional().HasMaxLength(1023);
        }
    }
}
