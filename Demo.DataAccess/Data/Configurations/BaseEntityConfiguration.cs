using Demo.DataAccess.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configurations
{
    internal class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(E => E.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(E => E.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
}
