
using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.DataAccess.Data.Configurations
{
    internal class DepartmentConfigurations : BaseEntityConfiguration<Department>, IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
           builder.Property(D=> D.Id).UseIdentityColumn(10,10);
            builder.Property(D => D.Name).HasColumnType("nvarchar(20)");
            builder.Property(D => D.Code).HasColumnType("varchar(20)");
           base.Configure(builder);
        }
    }
}
